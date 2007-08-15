// LolCodeVariable.cs
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
using System.Globalization;

namespace Rotfl
{
	
	
	public class LolCodeValue : LolCodeExpression
	{
		protected object lolvalue; 		
		
		public LolCodeValue(object val) {
			lolvalue = val;
		}
		
		virtual public string Yarn {
			get {
				throw new ApplicationException("Unknown value type: " + lolvalue.GetType().ToString());
			}
		}

		virtual public int Numbr {
			get {
				throw new ApplicationException("Unknown value type: " + lolvalue.GetType().ToString());
			}
		}

		virtual public double Numbar {
			get {
				throw new ApplicationException("Unknown value type: " + lolvalue.GetType().ToString());
			}
		}

		static public implicit operator LolCodeValue(string v) {
			return new LolCodeValueYarn(v);
		}

		static public implicit operator LolCodeValue(double v) {
			return new LolCodeValueNumbar(v);
		}

		static public implicit operator LolCodeValue(int v) {
			return new LolCodeValueNumbr(v);
		}

		public override LolCodeValue Evaluate () {
			return this;
		}

		public override void Run () {
			
		}

		public Type ValueType {
			get { return lolvalue.GetType(); }
		}
		
		public override string ToString () {
			return String.Format("({0}):\"{1}\"", ValueType, Yarn);
		}

	}

	public class LolCodeValueNumbr : LolCodeValue {
		public LolCodeValueNumbr(int val) : base(val) { }
		
		public override string Yarn {
			get { return ((int)lolvalue).ToString(); }
		}
		public override int Numbr {
			get { return ((int)lolvalue); }
		}
		public override double Numbar {
			get { return ((int)lolvalue); }
		}
	}

	public class LolCodeValueNumbar : LolCodeValue {
		public LolCodeValueNumbar(double val) : base(val) { }
		
		public override string Yarn {
			get { return ((double)lolvalue).ToString("0.00", CultureInfo.InvariantCulture); }
		}
		public override int Numbr {
			get { return (int)Math.Truncate((double)lolvalue); }
		}
		public override double Numbar {
			get { return ((double)lolvalue); }
		}
	}

	public class LolCodeValueYarn : LolCodeValue {
		public LolCodeValueYarn(string val) : base(val) { }
		
		public override string Yarn {
			get { return ((string)lolvalue); }
		}
		public override int Numbr {
			get { return int.Parse((string)lolvalue); }
		}
		public override double Numbar {
			get { return double.Parse((string)lolvalue, CultureInfo.InvariantCulture); }
		}
	}
}
