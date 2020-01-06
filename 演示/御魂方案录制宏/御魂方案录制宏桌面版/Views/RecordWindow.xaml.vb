Class RecordWindow
    Private Sub RecordWindow_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Application.Current.SplashWindow.Show()
    End Sub
End Class
