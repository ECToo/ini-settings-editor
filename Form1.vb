Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HideTabPage(ByVal tp As TabPage)
        If TabControl1.TabPages.Contains(tp) Then TabControl1.TabPages.Remove(tp)
    End Sub

    Private Sub ShowTabPage(ByVal tp As TabPage)
        ShowTabPage(tp, TabControl1.TabPages.Count)
    End Sub

    Private Sub ShowTabPage(ByVal tp As TabPage, ByVal index As Integer)
        If TabControl1.TabPages.Contains(tp) Then Return
        InsertTabPage(tp, index)
    End Sub

    Private Sub InsertTabPage(ByVal [tabpage] As TabPage, ByVal [index] As Integer)
        If [index] < 0 Or [index] > TabControl1.TabCount Then
            Throw New ArgumentException("Index out of Range.")
        End If
        TabControl1.TabPages.Add([tabpage])
        If [index] < TabControl1.TabCount - 1 Then
            Do While TabControl1.TabPages.IndexOf([tabpage]) <> [index]
                SwapTabPages([tabpage], (TabControl1.TabPages(TabControl1.TabPages.IndexOf([tabpage]) - 1)))
            Loop
        End If
        TabControl1.SelectedTab = [tabpage]
    End Sub

    Private Sub SwapTabPages(ByVal tp1 As TabPage, ByVal tp2 As TabPage)
        If TabControl1.TabPages.Contains(tp1) = False Or TabControl1.TabPages.Contains(tp2) = False Then
            Throw New ArgumentException("TabPages must be in the TabCotrols TabPageCollection.")
        End If
        Dim Index1 As Integer = TabControl1.TabPages.IndexOf(tp1)
        Dim Index2 As Integer = TabControl1.TabPages.IndexOf(tp2)
        TabControl1.TabPages(Index1) = tp2
        TabControl1.TabPages(Index2) = tp1

        'Uncomment the following section to overcome bugs in the Compact Framework
        'TabControl1.SelectedIndex = TabControl1.SelectedIndex 
        'Dim tp1Text, tp2Text As String
        'tp1Text = tp1.Text
        'tp2Text = tp2.Text
        'tp1.Text=tp2Text
        'tp2.Text=tp1Text

    End Sub
End Class