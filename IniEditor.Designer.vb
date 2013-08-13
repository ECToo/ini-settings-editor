<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IniEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IniEditor))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadLastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeveloperModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.OpenINIFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenContainingFolderOfINIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.TabControlSections = New System.Windows.Forms.TabControl
        Me.ImageListForTabs = New System.Windows.Forms.ImageList(Me.components)
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.ButtonOk = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.LoadLastToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(627, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'LoadLastToolStripMenuItem
        '
        Me.LoadLastToolStripMenuItem.Name = "LoadLastToolStripMenuItem"
        Me.LoadLastToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.LoadLastToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.LoadLastToolStripMenuItem.Text = "Load Last"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeveloperModeToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.ToolStripMenuItem1, Me.OpenINIFileToolStripMenuItem, Me.OpenContainingFolderOfINIToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'DeveloperModeToolStripMenuItem
        '
        Me.DeveloperModeToolStripMenuItem.Name = "DeveloperModeToolStripMenuItem"
        Me.DeveloperModeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DeveloperModeToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.DeveloperModeToolStripMenuItem.Text = "Developer Mode On/Off"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh INI"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(241, 6)
        '
        'OpenINIFileToolStripMenuItem
        '
        Me.OpenINIFileToolStripMenuItem.Name = "OpenINIFileToolStripMenuItem"
        Me.OpenINIFileToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.OpenINIFileToolStripMenuItem.Text = "Open INI file"
        '
        'OpenContainingFolderOfINIToolStripMenuItem
        '
        Me.OpenContainingFolderOfINIToolStripMenuItem.Name = "OpenContainingFolderOfINIToolStripMenuItem"
        Me.OpenContainingFolderOfINIToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.OpenContainingFolderOfINIToolStripMenuItem.Text = "Open containing folder of INI"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 27)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(392, 342)
        Me.ListBox1.TabIndex = 1
        '
        'TabControlSections
        '
        Me.TabControlSections.ImageList = Me.ImageListForTabs
        Me.TabControlSections.Location = New System.Drawing.Point(0, 27)
        Me.TabControlSections.Name = "TabControlSections"
        Me.TabControlSections.SelectedIndex = 0
        Me.TabControlSections.Size = New System.Drawing.Size(627, 343)
        Me.TabControlSections.TabIndex = 2
        '
        'ImageListForTabs
        '
        Me.ImageListForTabs.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageListForTabs.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListForTabs.TransparentColor = System.Drawing.Color.Transparent
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(518, 376)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(97, 23)
        Me.ButtonCancel.TabIndex = 3
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOk
        '
        Me.ButtonOk.Location = New System.Drawing.Point(415, 376)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(97, 23)
        Me.ButtonOk.TabIndex = 4
        Me.ButtonOk.Text = "Save && Close"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'IniEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 403)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.TabControlSections)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "IniEditor"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "INI Settings Editor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents LoadLastToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeveloperModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenINIFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenContainingFolderOfINIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControlSections As System.Windows.Forms.TabControl
    Friend WithEvents ImageListForTabs As System.Windows.Forms.ImageList
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOk As System.Windows.Forms.Button

End Class
