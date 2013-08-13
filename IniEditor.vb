Public Class IniEditor

    Dim MyINI As String
    Dim Vars As New Dictionary(Of String, IniVar)
    Dim DevMode As Boolean = False

    Dim BasicSpeedyMode As Boolean = False

    Dim Face As New List(Of ControlLinkClass)


    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()

        MyINI = OpenFileDialog1.FileName

        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(MyINI)

        If Not fileExists Then
            MsgBox("File doesn't exist. Try again.")
            Exit Sub
        End If

        My.Settings.LastINI = MyINI

        My.Settings.Save()

        loadItUp()

    End Sub
    Public Function CapitalizeFirstLetter(ByVal str As String) As String

        If BasicSpeedyMode Then Return str

        Dim strFirstLetter As String = Microsoft.VisualBasic.UCase(Microsoft.VisualBasic.Left(str, 1))

        str = strFirstLetter & Microsoft.VisualBasic.Mid(str, 2, Microsoft.VisualBasic.Len(str) - 1)

        Return str
    End Function

    Public Function CapitalizeAcronyms(ByVal str As String) As String

        If BasicSpeedyMode Then Return str

        Dim res As String = str
        res = Replace(res, "smtp", "SMTP", , , CompareMethod.Text)
        res = Replace(res, "usa", "USA", , , CompareMethod.Text)
        res = Replace(res, "ftp", "FTP", , , CompareMethod.Text)
        'res = Replace(res, "smtp", "SMTP", , , CompareMethod.Text)
        'res = Replace(res, "smtp", "SMTP", , , CompareMethod.Text)
        'res = Replace(res, "smtp", "SMTP", , , CompareMethod.Text)
        'res = Replace(res, "smtp", "SMTP", , , CompareMethod.Text)

        Return res
    End Function


    Public Function StringHumanize(ByVal str As String) As String

        If BasicSpeedyMode Then Return str

        'If it has a space, its already humanized.
        If str.Contains(" ") Then Return str


        Dim res As String = ""

        Dim pos As Integer = 0
        Dim strVer As String
        Dim lastCharWasLowerCase As Boolean = False

        'HANDLE CASE: The String is all uppercase, which makes life a little hard
        'EX: MYSETTING or VALUE_OF_SERVER
        If str.ToUpper = str Then
            res = str.Replace("_", " ")
            res = Microsoft.VisualBasic.Strings.StrConv(res, VbStrConv.ProperCase, 0)
            Return CapitalizeAcronyms(res)
        End If

        If str.Contains("_") Then
            res = str.Replace("_", " ")
            Return CapitalizeFirstLetter(res)
        End If

        For Each c As Char In str
            strVer = c.ToString

            If Char.IsUpper(c) And pos > 0 Then

                If lastCharWasLowerCase = False Then
                    '2 uppercase letters... We assume its means to be one word, like LastIP, AddressUSA
                    res += strVer
                Else
                    res += " " + strVer
                End If
                lastCharWasLowerCase = False

            Else

                lastCharWasLowerCase = True
                res += strVer
            End If

            pos += 1
        Next

        res = CapitalizeFirstLetter(res)
        Return CapitalizeAcronyms(res)

    End Function

    Private Sub LoadLastToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadLastToolStripMenuItem.Click
        MyINI = My.Settings.LastINI
        loadItUp()
    End Sub

    Public Sub loadItUp()

        Vars = New Dictionary(Of String, IniVar)
        Face = New List(Of ControlLinkClass)

        Dim curTabImageIndex As Integer = 0

        ListBox1.Items.Clear()
        TabControlSections.TabPages.Clear()
        ImageListForTabs.Images.Clear()

        Dim separatorPic As PictureBox

        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(MyINI)

        If Not fileExists Then
            MsgBox("File doesn't exist. Try again.")
            Exit Sub
        End If

        Dim lines() As String = IO.File.ReadAllLines(MyINI)
        Dim lineArray As New ArrayList()

        Dim fileContents As String
        fileContents = My.Computer.FileSystem.ReadAllText(MyINI)


        Dim c As String
        Dim curSection As String = ""
        Dim curSectionTop As Integer = 0
        Dim curSectionFirstLineIndex As Integer = 0
        Dim cursectionLastLineIndex As Integer = 0
        Dim curSectionIconFullPath As String = ""

        Dim linesUB As Integer = lines.GetUpperBound(0)

        For x As Integer = 0 To linesUB
            'lineArray.Add(lines(x))
            c = lines(x)

            If x Mod 500 = 0 AndAlso x > 1000 Then
                Me.Text = "Processing line " + x.ToString + " of " + linesUB.ToString + "... " + curSection
                System.Windows.Forms.Application.DoEvents()
                Me.Refresh()
            End If

            If c.Contains("[") Then
                curSection = GetStringBetween(c, "[", "]")
                curSectionFirstLineIndex = x + 1

                cursectionLastLineIndex = linesUB
                For nn As Integer = x + 1 To linesUB
                    If lines(nn).StartsWith("[") Then
                        cursectionLastLineIndex = nn - 1
                        Exit For
                    End If
                Next

                Continue For
            End If

            If Trim(c) = "" Or c.Contains("_OPTION") _
                Or c.Contains("_DESC") _
                Or c.Contains("_VISIBLE") _
                Or c.Contains("_ICON") Then
                Continue For
            End If

            Dim v As New IniVar
            v.Visible = True
            v.VarName = GetStringBetween(c, "", "=")
            ' i use a little trick there.
            v.Section = curSection

            v.Value = GetStringBetween(c, "=", "")
            'another little hack which hopefully won't backfire.

            'GET ALL OPTIONAL VALUES and DESCRIPTION:
            Dim aa As String
            Dim foundDesc, foundVisible, foundIcon, foundGroupIcon As Boolean
            foundDesc = False
            foundVisible = False
            foundIcon = False
            foundGroupIcon = False
            Dim optionString As String = v.VarName + "_OPTION"
            Dim visibleString As String = v.VarName + "_VISIBLE"
            Dim descString As String = v.VarName + "_DESC"
            Dim iconString As String = v.VarName + "_ICON"
            Dim groupIconString As String = "GROUP_ICON"

            For q As Integer = curSectionFirstLineIndex To cursectionLastLineIndex
                aa = lines(q)
                If aa.Contains(optionString) Then
                    Dim anOption As String
                    anOption = GetStringBetween(aa, "=", "")
                    v.ValueOptions.Add(anOption)
                End If
                If foundDesc And foundVisible And foundIcon And foundGroupIcon Then
                    Continue For
                End If
                If aa.Contains(descString) Then
                    v.Desc = GetStringBetween(aa, "=", "")
                    foundDesc = True
                ElseIf aa.Contains(iconString) Then
                    Dim iconPath As String
                    iconPath = App_Path() + GetStringBetween(aa, "=", "")
                    v.IconFullPath = iconPath
                    foundIcon = True
                ElseIf aa.Contains(visibleString) Then
                    Dim showStr As String
                    showStr = GetStringBetween(aa, "=", "")
                    If showStr.ToUpper = "FALSE" Then
                        v.Visible = False
                    End If
                    foundVisible = True
                ElseIf aa.Contains(groupIconString) Then
                    curSectionIconFullPath = App_Path() + GetStringBetween(aa, "=", "")
                End If
            Next

            'v.ValueOptions.Add("option2")

            'Try
            'Vars.Add(v.VarName, v)
            'Catch ex As Exception
            '
            '           End Try

            If v.Visible Or DevMode Then
                ListBox1.Items.Add(v.VarName)
                Dim DoAdd As Boolean = True
                Dim curPage As TabPage = Nothing
                For Each ttab As TabPage In TabControlSections.TabPages
                    If ttab.Text = StringHumanize(curSection) Then
                        curPage = ttab
                        DoAdd = False
                    End If
                Next

                If DoAdd Then
                    'NEW TAB PAGE ADDED TOTAB CONTROL.
                    'First, IMPORTANT... For appearance reasons, make the last separator transparent (if it exists.. this might be
                    ' the first time we are creating a Tab Page.)
                    'NOTE: We make it transparent and not invisible because invisible causes it to just dissapear and then there's
                    'no margin in the control. (That looks odd, so we just make it transparent.)
                    If separatorPic IsNot Nothing Then
                        separatorPic.BackColor = Color.Transparent
                    End If

                    Dim thisTab As New TabPage(StringHumanize(curSection))
                    thisTab.BackColor = Color.White

                    If curSectionIconFullPath <> "" Then
                        Dim im As Image
                        Try
                            im = Image.FromFile(curSectionIconFullPath)
                            ImageListForTabs.Images.Add(im)
                            thisTab.ImageIndex = curTabImageIndex
                        Catch ex As Exception

                        End Try
                        curTabImageIndex += 1
                    End If
                    
                    thisTab.AutoScroll = True
                    thisTab.PerformLayout()
                    TabControlSections.TabPages.Add(thisTab)
                    curPage = thisTab
                    curSectionTop = 15
                End If

                If curPage Is Nothing Then
                    MsgBox("Error in INI: Section missing.")
                    Exit Sub
                Else
                    Dim leftBorder As Integer = 10
                    Dim lbl As New Label
                    Dim lbl_desc As New Label
                    separatorPic = New PictureBox

                    Dim hasIcon As Boolean = False
                    Dim cIcon As PictureBox

                    If v.IconFullPath <> "" Then
                        cIcon = New PictureBox
                        hasIcon = True
                        cIcon.SizeMode = PictureBoxSizeMode.StretchImage
                        cIcon.Width = 16
                        cIcon.Height = 16
                        Try
                            cIcon.ImageLocation = v.IconFullPath
                        Catch ex As Exception

                        End Try

                        cIcon.Left = leftBorder
                        cIcon.Top = curSectionTop - 2
                    End If

                    lbl.Font = New Font(lbl.Font, FontStyle.Bold)
                    lbl.Text = StringHumanize(v.VarName)
                    lbl.AutoSize = True
                    If hasIcon Then
                        lbl.Left = leftBorder + 18
                    Else
                        lbl.Left = leftBorder
                    End If

                    lbl.Top = curSectionTop

                    curSectionTop += lbl.Height

                    If v.Desc <> "" Then
                        lbl_desc.Text = v.Desc
                        lbl_desc.AutoSize = True
                        lbl_desc.Left = leftBorder
                        lbl_desc.AutoEllipsis = True
                        lbl_desc.Top = curSectionTop
                        curPage.Controls.Add(lbl_desc)
                        'lbl.Controls.Add(lbl_desc)

                        'If it passes one line, then increase the height so it's all visible.
                        If lbl_desc.Width >= curPage.Width + 50 Then
                            lbl_desc.AutoSize = False
                            lbl_desc.Width = curPage.Width - 50
                            lbl_desc.Height = lbl_desc.Height * 2
                        End If

                        curSectionTop += lbl_desc.Height + 5

                    End If

                    Dim ddb
                    If v.ValueOptions.Count = 0 Then
                        ddb = New TextBox
                    Else
                        ddb = New ComboBox
                    End If

                    Dim clink As New ControlLinkClass
                    clink.WindowsControl = ddb
                    clink.v = v
                    Face.Add(clink)

                    ddb.Left = leftBorder
                    ddb.Top = curSectionTop
                    curSectionTop += ddb.Height

                    For Each it As String In v.ValueOptions
                        ddb.Items.Add(it)
                    Next
                    ddb.Text = v.Value
                    ddb.Width = 200

                    curSectionTop += 15
                    separatorPic.BackColor = Color.Gray
                    separatorPic.Width = TabControlSections.Width - 65
                    separatorPic.Left = 10
                    separatorPic.Height = 1
                    separatorPic.Top = curSectionTop
                    curSectionTop += 15

                    If hasIcon Then
                        curPage.Controls.Add(cIcon)
                    End If
                    curPage.Controls.Add(lbl)
                    curPage.Controls.Add(ddb)
                    curPage.Controls.Add(separatorPic)

                    End If
            End If

        Next

        'Again some final work to make things look nice, we hide the last separator:
        If separatorPic IsNot Nothing Then
            separatorPic.BackColor = Color.Transparent
        End If

        Me.Text = "Settings Editor"

    End Sub

    Function GetStringBetween(ByVal source As String, ByVal Before As String, ByVal After As String) As String

        Dim p As Integer
        Dim temp As String

        GetStringBetween = ""

        If Before = "" Then
            p = 0
        Else
            p = source.IndexOf(Before)
        End If

        If p = -1 Then Exit Function

        p = p + Before.Length
        Dim p2
        If After = "" Then
            p2 = source.Length
        Else
            p2 = source.IndexOf(After, p)
        End If
        If p2 = -1 Then Exit Function
        'p2 = p2 - 1

        'Debug.Print(source.Length)

        temp = source.Substring(p, p2 - p)
        'MsgBox(temp)
        Return temp

    End Function

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim sk As String = ListBox1.SelectedItem.ToString

        'VariableEditor.SetUpVariable(MyINI, Vars(sk))
        'VariableEditor.ShowDialog()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Debug.Print("RES: {" + GetStringBetween("HELLO123END", "", "ELLO") + "}")


        'Debug.Print(StringHumanize("smtpServer"))
        'Debug.Print(StringHumanize("thisWeirdSetting"))
        'Debug.Print(StringHumanize("AndThisOneToo"))
        'Debug.Print(StringHumanize("Dont_forget_this"))



        Dim ss As String = ""

        If Command() = "" Then
            If IO.File.Exists(App_Path() + "Settings.ini") Then
                ss = App_Path() + "Settings.ini"
            End If
        Else
            Try
                'See if we are passed an INI file from the command line.
                ss = System.Environment.GetCommandLineArgs(1)
            Catch ex As Exception

            End Try
        End If

        Dim DevModeStr As String
        Try
            'See if we are passed an INI file from the command line.
            DevModeStr = System.Environment.GetCommandLineArgs(2)
            DevMode = DevModeStr.ToUpper = "DEV"
        Catch ex As Exception

        End Try

        ApplyDevMode()

        If ss <> "" Then
            MyINI = ss
            loadItUp()
        End If


    End Sub

    Sub ApplyDevMode()
        MenuStrip1.Visible = DevMode

    End Sub

    Private Sub DeveloperModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeveloperModeToolStripMenuItem.Click
        DevMode = Not DevMode
        ApplyDevMode()

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        loadItUp()
    End Sub

    Private Sub OpenINIFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenINIFileToolStripMenuItem.Click
        'Dim fullPathToINI As String = App_Path() + "\Snipia.ini"
        Microsoft.VisualBasic.Shell("notepad.exe " + MyINI, Microsoft.VisualBasic.AppWinStyle.NormalFocus)
    End Sub

    Public Function App_Path() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function

    Private Sub OpenContainingFolderOfINIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenContainingFolderOfINIToolStripMenuItem.Click
        Microsoft.VisualBasic.Shell("explorer /select," & App_Path(), Microsoft.VisualBasic.AppWinStyle.NormalFocus)
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        End
    End Sub

    
    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
        Dim ii As New IniFile(MyINI)

        For Each c As ControlLinkClass In Face
            Debug.Print(c.v.VarName + ": " + c.WindowsControl.Text)

            ii.WriteString(c.v.Section, c.v.VarName, c.WindowsControl.Text)
            'ii.WriteString(curVar.Section, curVar.VarName + "_DESC", DescText.Text)
        Next

        End
    End Sub
End Class
