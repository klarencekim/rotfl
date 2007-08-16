// Main.cs
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
// project created on 2007-08-14 at 23:43
using System;

namespace Rotfl
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			LolCodeBlock main = new LolCodeBlock();
			SlkLog log = new SlkLog();
			SlkToken tokens = new SlkToken("HAI , I HAS A var ITZ 999 , VISIBLE var , KTHXBYE", log);
			SlkError error = new SlkError(tokens, log);
			SlkAction action = new SlkAction(tokens, main);
			SlkParser.parse(1, action, tokens, error, log, SlkConstants.NT_LOLCODE_);
			
			main.Run();
		}
	}
}