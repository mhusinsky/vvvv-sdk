using System;
using System.Collections.Generic;
using System.Text;

namespace VVVV.Nodes.jQuery
{
	public class JQuery : IScriptGenerator
	{
		protected Queue<JQueryExpression> FStatements;

		public static JQuery GenerateDocumentReady(JQuery handler)
		{
			JQueryExpression documentReadyExpression = new JQueryExpression(Selector.DocumentSelector);
			documentReadyExpression.ApplyMethodCall("ready", new JavaScriptAnonymousFunction(handler));
			JQuery documentReady = new JQuery(documentReadyExpression);
			return documentReady;
		}

		public JQuery()
		{
			FStatements = new Queue<JQueryExpression>();
		}

		public JQuery(params JQueryExpression[] statements) : this()
		{
			for (int i = 0; i < statements.Length; i++)
			{
				FStatements.Enqueue(statements[i]);
			}
		}

		public bool PIsEmpty
		{
			get { return FStatements.Count == 0; }
		}
	

		#region IScriptGenerator Members

		public string PScript(int indentSteps, bool breakInternalLines, bool breakAfter)
		{
			string text = "";
			int numStatements = FStatements.Count;
			int count = 1;
			foreach (JQueryExpression statement in FStatements)
			{
				for (int i = 0; i < indentSteps; i++)
				{
					text += "\t";
				}

				text += statement.PScript(indentSteps, breakInternalLines, breakAfter) + ";";
				if (breakInternalLines && count != numStatements)
				{
					text += "\n";
				}
				count++;
			}
			if (breakAfter && numStatements > 0)
			{
				text += "\n";
			}
			return text;
		}

		#endregion
	}
}
