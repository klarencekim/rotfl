// LolCodeAssignment.cs
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
	public class LolCodeAssignment : LolCodeStatement
	{
		private string _var;
		private LolCodeContext _varContext;
		private bool _create;
		private LolCodeExpression _expr = null;
		
		public LolCodeAssignment(string var, LolCodeContext context) {
			_var = var;
			_varContext = context;
			_create = true;
		}

		public LolCodeAssignment(bool create, string var, LolCodeContext context, LolCodeExpression expr) {
			_create = create;
			_var = var;
			_varContext = context;
			_expr = expr;
		}

		public override void Run () {
			if(_create) {
				(_varContext as LolCodeBlock).AddVariable(_var);
			}
			
			(_varContext as LolCodeBlock).SetVariable(_var, _expr.Evaluate());
		}
	}
}
