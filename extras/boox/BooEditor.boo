namespace BooExplorer

import ICSharpCode.TextEditor
import ICSharpCode.TextEditor.Document
import ICSharpCode.TextEditor.Actions
import WeifenLuo.WinFormsUI
import System
import System.Windows.Forms
import System.Drawing
import Boo.Lang.Compiler
import Boo.Lang.Compiler.IO
import Boo.Lang.Compiler.Pipeline.Definitions

class BooEditor(Content):
	
	static NewFileName = "untitled.boo"
	
	_editor as TextEditorControl
	_main as MainForm
	
	[getter(FileName)]
	_fname as string
	
	[getter(IsDirty)]
	_dirty = false
	
	def constructor(main as MainForm):
		_main = main		
		_editor = TextEditorControl(Dock: DockStyle.Fill,
							Font: System.Drawing.Font("Lucida Console", 13.0),
							EnableFolding: true)

		_editor.Encoding = System.Text.Encoding.UTF8
		_editor.Document.FormattingStrategy = BooFormattingStrategy()
		_editor.Document.HighlightingStrategy = GetBooHighlighting()
		_editor.Document.DocumentChanged += _editor_DocumentChanged
		
		SuspendLayout()
		Controls.Add(_editor)
		self.AllowedStates = ContentStates.Document
		self.Text = NewFileName
		self.DockPadding.All = 1
		self.Menu = CreateMenu()
		ResumeLayout(false)
		
	TextArea:
		get:
			return _editor.ActiveTextAreaControl.TextArea
		
	TextContent:
		get:
			return _editor.Document.TextContent
			
	def GoTo(line as int):
		_editor.ActiveTextAreaControl.JumpTo(line, 1)
		
	def SaveFile():
		if _fname:
			_editor.SaveFile(_fname)
		else:
			dlg = SaveFileDialog(AddExtension: true,
							DefaultExt: ".boo",
							OverwritePrompt: true,
							Filter: "boo files (*.boo)|*.boo")
			if DialogResult.OK == dlg.ShowDialog():
				_editor.SaveFile(dlg.FileName)
				_fname = dlg.FileName
				
		_dirty = false
		self.Text = _fname
		
	def LoadFile([required] fname as string):
		_editor.LoadFile(fname)
		self.Text = _fname = fname
		_dirty = false		
	
	def _editor_DocumentChanged(sender, args as DocumentEventArgs):
		if not _dirty:
			self.Text = "${GetSafeFileName()} (modified)"
			_dirty = true
		
	def _menuItemRun_Click(sender, args as EventArgs):
		savedCursor = Cursor
		self.Cursor = Cursors.WaitCursor
		
		compiler = BooCompiler()
		compiler.Parameters.Input.Add(StringInput(GetSafeFileName(), self.TextContent))
		compiler.Parameters.Pipeline.Load(BoomPipelineDefinition)
		
		started = date.Now
		result = compiler.Run()
		finished = date.Now
		_main.StatusText = "Compilation finished in ${finished-started} with ${len(result.Errors)} error(s)."
		
		if len(result.Errors):
			print(join(result.Errors, "\n"))
		else:
			try:
				result.GeneratedAssemblyEntryPoint.Invoke(null, (null,))
			except x:
				print(x)
				
		self.Cursor = savedCursor
		
	def GetSafeFileName():
		if _fname:
			return _fname
		return NewFileName
		
	def CreateMenu():
		menu = MainMenu()
		
		script = MenuItem(Text: "&Script")
		script.MenuItems.Add(MenuItem(Text: "Run",
									Click: _menuItemRun_Click,
									Shortcut: Shortcut.F5))
		
		menu.MenuItems.AddRange((script,))
		return menu
		
	def GetBooHighlighting():
		return HighlightingManager.Manager.FindHighlighter("boo")
		
	
