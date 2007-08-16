// LolCodeFunction.cs
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
using System.Collections.Generic;

namespace Rotfl
{
	public class LolCodeFunction : LolCodeExpression
	{
		private List<LolCodeExpression> _args = new List<LolCodeExpression>();
		private string _name;
		
		private LolCodeFunction(LolCodeContext ctx, string name) : base(ctx) {
			_name = name;
		}
		
		public static LolCodeFunction Create(LolCodeContext ctx, string name) {
			// lookup build-ins... do it in pretty way 
			return new LolCodeFunction(ctx, name); 
		}
		
		public void Add(LolCodeExpression expr) {
			_args.Add(expr);
		}
		
		public override LolCodeValue Evaluate () {
//			Console.WriteLine("running {0}", _name);
			
			switch(_name) {
			case "VISIBLE":
				foreach(LolCodeExpression exp in _args) {
					Console.Write(exp.Evaluate().Yarn);
				}
				Console.WriteLine();
				return new LolCodeValue(null);
			case "SUM": {
				LolCodeValue a1 = _args[0].Evaluate();
				LolCodeValue a2 = _args[1].Evaluate();
				if(a1.ValueType==typeof(int) && a2.ValueType==typeof(int))
					return (LolCodeValue)(a1.Numbr+a2.Numbr);
				else if(a1.ValueType==typeof(double) || a2.ValueType==typeof(double))
					return (LolCodeValue)(a1.Numbar+a2.Numbar);
				else // TODO - check casting
					return (LolCodeValue)(a1.Numbar+a2.Numbar);
			}
			case "DIFF": {
				LolCodeValue a1 = _args[0].Evaluate();
				LolCodeValue a2 = _args[1].Evaluate();
				if(a1.ValueType==typeof(int) && a2.ValueType==typeof(int))
					return (LolCodeValue)(a1.Numbr-a2.Numbr);
				else if(a1.ValueType==typeof(double) || a2.ValueType==typeof(double))
					return (LolCodeValue)(a1.Numbar-a2.Numbar);
				else // TODO - check casting
					return (LolCodeValue)(a1.Numbar-a2.Numbar);
			}
			case "PRODUKT": {
				LolCodeValue a1 = _args[0].Evaluate();
				LolCodeValue a2 = _args[1].Evaluate();
				if(a1.ValueType==typeof(int) && a2.ValueType==typeof(int))
					return (LolCodeValue)(a1.Numbr*a2.Numbr);
				else if(a1.ValueType==typeof(double) || a2.ValueType==typeof(double))
					return (LolCodeValue)(a1.Numbar*a2.Numbar);
				else // TODO - check casting
					return (LolCodeValue)(a1.Numbar*a2.Numbar);
			}
			case "QUOSHUNT": {
				LolCodeValue a1 = _args[0].Evaluate();
				LolCodeValue a2 = _args[1].Evaluate();
				if(a1.ValueType==typeof(int) && a2.ValueType==typeof(int))
					return (LolCodeValue)(a1.Numbr/a2.Numbr);
				else if(a1.ValueType==typeof(double) || a2.ValueType==typeof(double))
					return (LolCodeValue)(a1.Numbar/a2.Numbar);
				else // TODO - check casting
					return (LolCodeValue)(a1.Numbar/a2.Numbar);
			}
			case "MOD": {
				LolCodeValue a1 = _args[0].Evaluate();
				LolCodeValue a2 = _args[1].Evaluate();
				if(a1.ValueType==typeof(int) && a2.ValueType==typeof(int))
					return (LolCodeValue)(a1.Numbr%a2.Numbr);
				else if(a1.ValueType==typeof(double) || a2.ValueType==typeof(double))
					return (LolCodeValue)(a1.Numbar%a2.Numbar);
				else // TODO - check casting
					return (LolCodeValue)(a1.Numbar%a2.Numbar);
			}
			case "BIGGR": {
				LolCodeValue a1 = _args[0].Evaluate();
				LolCodeValue a2 = _args[1].Evaluate();
				return a1.Numbar>a2.Numbar?a1:a2;
			}
			case "SMALLR": {
				LolCodeValue a1 = _args[0].Evaluate();
				LolCodeValue a2 = _args[1].Evaluate();
				return a1.Numbar<a2.Numbar?a1:a2;
			}
			default:
				return new LolCodeValue(null);
			}
		}

		public override void Run () {
			Evaluate();
		}

	}
}
