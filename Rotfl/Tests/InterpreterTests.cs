// InterpreterTests.cs
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
using System.IO;
using NUnit.Framework;

namespace Rotfl
{
	
	
	[TestFixture]
	public class InterpreterTests
	{
		StringWriter sw;
		LolCodeBlock main;
		SlkLog log;
		SlkToken tokens;
		SlkError error;
		SlkAction action;
				
		[SetUp]
		public void Init() {
			log = new SlkLog();
		}

		[TearDown]
		public void Dispose() {
			main = null;
			Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
		}

		private void _runParser(string program) {
			sw = new StringWriter();
			Console.SetOut(sw);

			main = new LolCodeBlock();
			tokens = new SlkToken(program, log);
			error = new SlkError(tokens, log);
			action = new SlkAction(tokens, main);
			SlkParser.parse(0, action, tokens, error, log, SlkConstants.NT_LOLCODE_);
			
			main.Run();
		}
		
		[Test]
		public void EmptyProgram() {
			_runParser("HAI , KTHXBYE");
			Assert.AreEqual("", sw.ToString());
		}

		[Test]
		public void Visible() {
			_runParser("HAI , VISIBLE 666 , KTHXBYE");
			Assert.AreEqual("666\n", sw.ToString());
		}

		[Test]
		public void VisibleSum() {
			_runParser("HAI , VISIBLE SUM OF 123 AN 1.23 , KTHXBYE");
			Assert.AreEqual("124.23\n", sw.ToString());
		}

		[Test]
		public void VisibleSumVisible() {
			_runParser("HAI , VISIBLE SUM OF 123 AN 1.23 , VISIBLE 123 , KTHXBYE");
			Assert.AreEqual("124.23\n123\n", sw.ToString());
		}

		[Test]
		public void VisibleNoNl() {
			_runParser("HAI , VISIBLE 123 ! , KTHXBYE");
			Assert.AreEqual("123", sw.ToString());
		}

		[Test]
		public void BuildinMathSum() {
			_runParser("HAI , VISIBLE SUM OF 1 AN 2 , KTHXBYE");
			Assert.AreEqual("3\n", sw.ToString(), "sum");

			_runParser("HAI , VISIBLE DIFF OF 1 AN 2 , KTHXBYE");
			Assert.AreEqual("-1\n", sw.ToString(), "diff");

			_runParser("HAI , VISIBLE PRODUKT OF 1 AN 2 , KTHXBYE");
			Assert.AreEqual("2\n", sw.ToString(), "produkt");

			_runParser("HAI , VISIBLE QUOSHUNT OF 1 AN 2 , KTHXBYE");
			Assert.AreEqual("0\n", sw.ToString(), "quoshunt int");
			_runParser("HAI , VISIBLE QUOSHUNT OF 1 AN 2. , KTHXBYE");
			Assert.AreEqual("0.50\n", sw.ToString(), "quoshunt float");

			_runParser("HAI , VISIBLE MOD OF 10 AN 3 , KTHXBYE");
			Assert.AreEqual("1\n", sw.ToString(), "mod");

			_runParser("HAI , VISIBLE BIGGR OF 10 AN 3 , KTHXBYE");
			Assert.AreEqual("10\n", sw.ToString(), "biggr");

			_runParser("HAI , VISIBLE SMALLR OF 10 AN 3 , KTHXBYE");
			Assert.AreEqual("3\n", sw.ToString(), "smallr");
		}

		[Test]
		public void Variable() {
			_runParser("HAI , I HAS A var ITZ 999 , VISIBLE var , KTHXBYE");
			Assert.AreEqual("999\n", sw.ToString());
		}
	}
}
