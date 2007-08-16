// Scanner.cs
//
// Copyright (c) 2007 Stanisław Pitucha
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

using System;
using System.Text.RegularExpressions;

namespace Rotfl
{
	
	public class Scanner
	{
		protected SlkLog log;
		private short last_value;
		private string attribute;
		private string last_attribute;
		private string expr;
		private int start;
		private int length;
		private Regex _reIdentifier = new Regex(@"\G[a-zA-Z]+[0-9a-zA-Z_]*", RegexOptions.Compiled);
		private Regex _reInteger = new Regex(@"\G[-]?[0-9]+", RegexOptions.Compiled);
		private Regex _reFloat = new Regex(@"\G[-]?([0-9]*\.[0-9]+|[0-9]+\.)", RegexOptions.Compiled);
		private Regex _reIHasA = new Regex(@"\GI\s+HAS\s+A", RegexOptions.Compiled);
		

		internal Scanner(string input, SlkLog log) {
			this.log = log;
			expr = input;
			length = expr.Length;
			start = 0;
		}

		public string Attribute {
			get { return last_attribute; }
		}
		
		public LolCodeValue GetValue() {
//			Console.WriteLine("--- Token is: {0} ---", last_value);
			switch(last_value) {
			case SlkConstants.NUMBAR_:
				return (LolCodeValue)(double.Parse(Attribute, System.Globalization.CultureInfo.InvariantCulture));
			case SlkConstants.NUMBR_:
				return (LolCodeValue)(int.Parse(Attribute));
			case SlkConstants.IDENTIFIER_:
				return new LolCodeValueVariable(Attribute);
			default:
				return (LolCodeValue)Attribute;
			}
		}
		
		public short get () {
			short token = 0;
			Match m = null;

			while (start < length && Char.IsWhiteSpace (expr[start])) {
				++start;
			}
			last_attribute = attribute;
			
			
			if (start >= length) {
				token = SlkConstants.END_OF_SLK_INPUT_;
				return token;
			}
			
			if(expr.StartsWith("\r\n")) {
				start+=2;
				while(start<expr.Length && Char.IsWhiteSpace(expr[start]))
					start++;
				
				token = SlkConstants.STATEMENT_SEPARATOR_;
				attribute = null;
				return token;
			}

			if (expr[start]==',' || expr[start]=='\n' || expr[start]=='\r') {
				start++;
				while(start<expr.Length && Char.IsWhiteSpace(expr[start]))
					start++;
				
				token = SlkConstants.STATEMENT_SEPARATOR_;
				attribute = null;
				return token;
			}	
			
			m = _reFloat.Match(expr, start);
			if(m.Success) {
				last_value = token = SlkConstants.NUMBAR_;
				attribute = expr.Substring(start, m.Length);
				start += m.Length;
				
				while(start<expr.Length && Char.IsWhiteSpace(expr[start]))
					start++;
				return token;
			}
			
			m = _reInteger.Match(expr, start);
			if(m.Success) {
				last_value = token = SlkConstants.NUMBR_;
				attribute = expr.Substring(start, m.Length);
				start += m.Length;
				
				while(start<expr.Length && Char.IsWhiteSpace(expr[start]))
					start++;
				return token;
			}

			m = _reIHasA.Match(expr, start);
			if(m.Success) {
				if(((start+m.Length) < (expr.Length-1)) && (Char.IsLetterOrDigit(expr[start+m.Length]) || expr[start+m.Length]=='_')) {
					// stupid situation - don't even care...
					// I HAS AMERICA
				} else {
					token = SlkConstants.I_HAS_A_;

					start += m.Length;
				
					while(start<expr.Length && Char.IsWhiteSpace(expr[start]))
						start++;

					return token;
				}	
			}
			
			m = _reIdentifier.Match(expr, start);
			if(m.Success) {
				bool skip = false;
				switch(m.Groups[0].Value) {
				case "HAI":
					token = SlkConstants.HAI_; skip=true; break;
				case "KTHXBYE":
					token = SlkConstants.KTHXBYE_; skip=true; break;
				case "BIGGR":
					token = SlkConstants.BIGGR_; break;
				case "SMALLR":
					token = SlkConstants.SMALLR_; break;
				case "OF":
					token = SlkConstants.OF_; skip=true; break;
				case "SUM":
					token = SlkConstants.SUM_; break;
				case "DIFF":
					token = SlkConstants.DIFF_; break;
				case "PRODUKT":
					token = SlkConstants.PRODUKT_; break;
				case "QUOSHUNT":
					token = SlkConstants.QUOSHUNT_; break;
				case "MOD":
					token = SlkConstants.MOD_; break;
				case "VISIBLE":
					token = SlkConstants.VISIBLE_; break;
				case "GIMME":
					token = SlkConstants.GIMME_; break;
				case "AN":
					token = SlkConstants.AN_; break;
				case "ITZ":
					token = SlkConstants.ITZ_; skip=true; break;
				default:
					last_value = token = SlkConstants.IDENTIFIER_; break;
				}

				
				if(skip==false) // binary op handling
					attribute = expr.Substring(start, m.Length);
				
				start += m.Length;
				
				while(start<expr.Length && Char.IsWhiteSpace(expr[start]))
					start++;
				return token;
			}

			return  token;
		}
	}
}
