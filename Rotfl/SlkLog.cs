// SlkLog.cs
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

namespace Rotfl
{
	
	
	public class SlkLog
	{
		public void trace (string message) {
			Console.WriteLine ( message );
		}

		public void trace_depth (string message, int depth) {
			int i;

			for (i = 0; i < depth; ++i) {
				Console.WriteLine ( "    " );
			}
			Console.WriteLine (message);
		}

		public void trace_production (short production_number) {
			Console.WriteLine ( SlkString.GetProductionName ( production_number ) );
			Console.WriteLine ( "\n" );
		}

		public void trace_action (short action_number) {
			Console.WriteLine ( "\n" );
			Console.WriteLine ( SlkString.GetSymbolName ( action_number ) );
			Console.WriteLine ( "\n\n" );
		}
	}
}
