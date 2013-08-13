Public Class VariableEditor

    Dim curVar As IniVar
    Dim curFileName As String


    Private Sub VariableEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub SetUpVariable(ByVal iniFile As String, ByVal ivar As IniVar)

        ComboBox1.Text = ""
        ComboBox1.Items.Clear()
        DescText.ReadOnly = True

        Label1.Text = ivar.VarName
        DescText.Text = ivar.desc

        ' We change the reference to ivar....
        curVar = ivar

        curFileName = iniFile

        For Each tt As String In ivar.ValueOptions
            ComboBox1.Items.Add(tt)
        Next

        ComboBox1.Text = curVar.Value

    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim ii As New IniFile(curFileName)

        ii.WriteString(curVar.Section, curVar.VarName, ComboBox1.Text)
        ii.WriteString(curVar.Section, curVar.VarName + "_DESC", DescText.Text)

        IniEditor.loadItUp()

        Me.Close()

    End Sub

    Private Sub DescText_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DescText.MouseDoubleClick
        DescText.ReadOnly = False
    End Sub

    Private Sub DescText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescText.TextChanged

    End Sub
End Class