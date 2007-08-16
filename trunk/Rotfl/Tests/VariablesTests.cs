// VariablesTests.cs
//
// Copyright (c) 2007 [copyright holders]
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
	public class VariablesTests {
		
		[Test]
		public void VariableContextSearch() {
			LolCodeBlock blk = new LolCodeBlock();
			LolCodeBlock chl_blk = new LolCodeBlock(blk);
			
			Assert.AreSame(blk, LolCodeBlock.GetNextVariableContext(blk), "same context");
			Assert.AreSame(blk, LolCodeBlock.GetNextVariableContext(chl_blk), "child context");
		}

		[Test]
		public void VariableSearch() {
			LolCodeBlock blk = new LolCodeBlock();
			LolCodeBlock chl_blk = new LolCodeBlock(blk);
			
			LolCodeValue tmp = (LolCodeValue)10;
			
			blk.AddVariable("abc");
			blk.SetVariable("abc", tmp);
			
			Assert.AreSame(tmp, blk.GetVariable("abc"), "set main, get main");
			Assert.AreSame(tmp, chl_blk.GetVariable("abc"), "set main, get child");

			tmp = (LolCodeValue)20;

			chl_blk.AddVariable("def");
			chl_blk.SetVariable("def", tmp);

			Assert.AreSame(tmp, blk.GetVariable("def"), "set child, get main");
			Assert.AreSame(tmp, chl_blk.GetVariable("def"), "set child, get child");
		}

		[Test]
		[ExpectedException( typeof( NullReferenceException ) )]
		// Stupid, but let it be for now
		public void VariableUninitialized() {
			LolCodeBlock blk = new LolCodeBlock();
			
			blk.AddVariable("abc");
			LolCodeValue tmp = blk.GetVariable("abc");
			
			Assert.AreEqual(null, tmp.ValueType);
		}
	}
}
