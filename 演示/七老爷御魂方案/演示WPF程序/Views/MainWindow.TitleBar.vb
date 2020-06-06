Imports Nukepayload2.Linq.Onmyoji

Partial Class MainWindow

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        MsgBox($"版本 1.1, 适配{痒痒熊快照.已适配的产品和版本}。
作者: 
B站、GitHub、百度贴吧、微博：Nukepayload2。
阴阳师：依偎相守#2723416
攻略：
B站 解说七老爷,这里阿毛酱", vbInformation, "关于")
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnViewSource_Click(sender As Object, e As RoutedEventArgs) Handles BtnViewSource.Click
        Process.Start("explorer.exe", "https://github.com/Nukepayload2/LinqToOnmyoji")
    End Sub

    Private Sub BtnMin_Click(sender As Object, e As RoutedEventArgs) Handles BtnMin.Click
        WindowState = WindowState.Minimized
    End Sub
End Class
