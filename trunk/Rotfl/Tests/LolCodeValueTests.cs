// LolCodeValueTests.cs
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
using NUnit.Framework;

namespace Rotfl
{
	
	
	[TestFixture]
	public class LolCodeValueTests
	{
		
		[Test]
		public void Creation() {
			LolCodeValue one = (LolCodeValue) 1;
			Assert.IsInstanceOfType(typeof(LolCodeValueNumbr), one);

			LolCodeValue onePointOh = (LolCodeValue) 1.0;
			Assert.IsInstanceOfType(typeof(LolCodeValueNumbar), onePointOh);

			LolCodeValue abc = (LolCodeValue) "abc";
			Assert.IsInstanceOfType(typeof(LolCodeValueYarn), abc);
		}
		
		[Test]
		public void IntConversions() {
			LolCodeValue v = (LolCodeValue) 1;
			Assert.AreEqual("1", v.Yarn);
			Assert.AreEqual(1.0, v.Numbar);
			Assert.AreEqual(1, v.Numbr);
		}

		[Test]
		public void DoubleConversions() {
			LolCodeValue v = (LolCodeValue) 1.0;
			Assert.AreEqual("1.00", v.Yarn);
			Assert.AreEqual(1.0, v.Numbar);
			Assert.AreEqual(1, v.Numbr);

			v = (LolCodeValue) 1.6;
			Assert.AreEqual(1, v.Numbr);

			v = (LolCodeValue) (-1.6);
			Assert.AreEqual(-1, v.Numbr);
		}
	}
}
