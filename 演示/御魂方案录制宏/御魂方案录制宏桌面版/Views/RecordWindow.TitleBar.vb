Partial Class RecordWindow

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        ShowAboutCommand.Instance.Execute(Nothing)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Private Sub BtnViewSource_Click(sender As Object, e As RoutedEventArgs) Handles BtnViewSource.Click
        Process.Start("explorer.exe", "https://github.com/Nukepayload2/LinqToOnmyoji")
    End Sub

End Class
