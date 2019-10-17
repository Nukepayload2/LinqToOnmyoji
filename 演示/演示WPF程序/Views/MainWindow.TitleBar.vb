Partial Class MainWindow

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        MsgBox("版本 1.0 preview 5, 适配痒痒熊导出器 0.99.1。
作者: 
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
