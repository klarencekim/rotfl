// SlkAction.cs
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
	
	public class SlkAction
	{
		private Stack<LolCodeContext> _contexts = new Stack<LolCodeContext>();
		private Stack<LolCodeExpression> _expressions = new Stack<LolCodeExpression>();
		private Scanner _scanner;
		
		internal SlkAction(Scanner scanner, LolCodeBlock program_block) {
			_contexts.Push(program_block);
			_scanner = scanner;
		}

		private void StartBlock() {
			LolCodeBlock nb = new LolCodeBlock();
			((LolCodeBlock) _contexts.Peek()).Add(nb);
			_contexts.Push(nb);
		}

		private void EndBlock() {
			_contexts.Pop();
		}
		
		private void PushStatement() {
			(_contexts.Peek() as LolCodeBlock).Add(_expressions.Pop());
		}
		
		private void PushValue() {
			_expressions.Push(_scanner.GetValue());
		}
		
		private void StartFunction() {
			LolCodeFunction func = LolCodeFunction.Create(_scanner.Attribute);
/*			LolCodeContext ctx = _contexts.Peek();
			if(ctx is LolCodeBlock) {
				((LolCodeBlock) ctx).Add(func);
			} else if(ctx is LolCodeFunction) {
				((LolCodeFunction) ctx).Add(func);
			} else {
				throw new ApplicationException("Unknown context.");
			}*/
			_contexts.Push(func);
		}

		private void PopArgument() { // add argument to function
			LolCodeFunction func = _contexts.Peek() as LolCodeFunction;
			func.Add(_expressions.Pop());
		}
		
		private void EndFunction() {
			_expressions.Push((LolCodeFunction) _contexts.Pop());
		}

		private void AssignIt() {
			// TODO - add assign statement to block
		}

		public void execute(int number)
		{
			switch ( number ) {
			case 1:  StartBlock();  break;
			case 2:  EndBlock();  break;
			case 3:  PushStatement();  break;
			case 4:  AssignIt();  break;
			case 5:  StartFunction();  break;
			case 6:  PopArgument();  break;
			case 7:  EndFunction();  break;
			case 8:  PushValue();  break;
			}
		}
	}
}
