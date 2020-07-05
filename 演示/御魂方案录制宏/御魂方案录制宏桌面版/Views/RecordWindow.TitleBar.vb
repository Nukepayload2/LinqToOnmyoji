Partial Class RecordWindow

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        ShowAboutCommand.Instance.Execute(Nothing)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnViewSource_Click(sender As Object, e As RoutedEventArgs) Handles BtnViewSource.Click
        Process.Start("explorer.exe", "https://github.com/Nukepayload2/LinqToOnmyoji")
    End Sub

    Private Sub BtnMinimize_Click(sender As Object, e As RoutedEventArgs) Handles BtnMinimize.Click
        WindowState = WindowState.Minimized
    End Sub
End Class
