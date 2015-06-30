using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using Mono.TextEditor;

namespace DiffCopyPastaFixer
{
	public enum DiffCopyPastaFixerCommands
	{
		RemoveDiffLines,
	}

	public class RemoveDiffLinesHandler : CommandHandler
	{
		static int GetIndexOfDiffSymbol (string text)
		{
			for (int i = 0; i < text.Length; ++i) {
				if (Char.IsWhiteSpace (text [i]))
					continue;

				if (text [i] == '+' || text [i] == '-')
					return i;

				break;
			}
			return -1;
		}

		protected override void Run ()
		{
			var editor = IdeApp.Workbench.ActiveDocument.GetContent<ITextEditorDataProvider> ().GetTextEditorData ();

			foreach (var line in editor.SelectedLines) {
				var text = editor.GetLineText (line.LineNumber);
				var start = GetIndexOfDiffSymbol (text);
				if (start == -1)
					continue;

				editor.Remove (line.Offset + start, 1);
			}
		}

		protected override void Update (CommandInfo info)
		{
			var doc = IdeApp.Workbench.ActiveDocument;
			info.Enabled = doc != null;
		}
	}
}
