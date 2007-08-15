// LolCodeBlock.cs
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
	public class LolCodeBlock : LolCodeStatement
	{
		private List<LolCodeStatement> _statements = new List<Rotfl.LolCodeStatement>();
		private Dictionary<string,LolCodeValue> _variables;
		
		public LolCodeBlock(LolCodeContext parent) : base(parent) { }
		public LolCodeBlock() : this(null) {
			_variables = new Dictionary<string,LolCodeValue>();
			_variables.Add("IT", new LolCodeValue(null));
		}
		
		public void Add(LolCodeStatement statement) {
			_statements.Add(statement);
		}
		
		override public void Run() {
			foreach(LolCodeStatement statement in _statements)
				statement.Run();
		}
		
		public void AddVariable(string name) {
			LolCodeContext con = this;
			while(con!=null) {
				if(con is LolCodeBlock) {
					Dictionary<string,LolCodeValue> vars = (con as LolCodeBlock)._variables;
					if(vars!=null) {
						vars.Add(name, new LolCodeValue(null));
					}
				}
			}
			
			throw new ApplicationException("Can't find context with vars!");
		}
		
		public void SetVariable(string name, LolCodeValue val) {
			LolCodeContext con = this;
			while(con!=null) {
				if(con is LolCodeBlock) {
					Dictionary<string,LolCodeValue> vars = (con as LolCodeBlock)._variables;
					if(vars!=null) {
						if(vars.ContainsKey(name)) {
							vars[name] = val;
							return;
						}
					}
				}
				// TODO: is it LolFunctionBlock? that will have own variables
			}
			
			throw new ApplicationException("No variable '"+name+"' defined!");
		}

		public LolCodeValue GetVariable(string name) {
			LolCodeContext con = this;
			while(con!=null) {
				if(con is LolCodeBlock) {
					Dictionary<string,LolCodeValue> vars = (con as LolCodeBlock)._variables;
					if(vars!=null) {
						if(vars.ContainsKey(name)) {
							return vars[name];
						}
					}
				}
				// TODO: is it LolFunctionBlock? that will have own variables
			}
			
			throw new ApplicationException("No variable '"+name+"' defined!");
		}
	}
}
