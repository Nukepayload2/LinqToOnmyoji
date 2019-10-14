Partial Class MainWindow

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        MsgBox("作者: 
B站、GitHub、百度贴吧、微博：Nukepayload2。
阴阳师：依偎相守#2723416
攻略：
B站 解说七老爷", vbInformation, "关于")
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Private Sub BtnViewSource_Click(sender As Object, e As RoutedEventArgs) Handles BtnViewSource.Click
        Process.Start("explorer.exe", "https://github.com/Nukepayload2/LinqToOnmyoji")
    End Sub

End Class
