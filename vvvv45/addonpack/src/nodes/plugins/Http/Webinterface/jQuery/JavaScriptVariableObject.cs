using System;
using System.Collections.Generic;
using System.Text;

namespace VVVV.Nodes.jQuery
{
	public class JavaScriptVariableObject : JavaScriptObject
	{
		protected string FVariableName;

		public JavaScriptVariableObject(string variableName)
		{
			FVariableName = variableName;
		}
		
		public override string PScript(int indentSteps, bool breakInternalLines, bool breakAfter)
		{
			return FVariableName;
		}
	}
}
