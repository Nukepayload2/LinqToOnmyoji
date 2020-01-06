Public Class SplashWindow
    Private Sub TitleBarDragElement_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles TitleBarDragElement.PreviewMouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        MsgBox("版本: " + GetType(SplashWindow).Assembly.GetName.Version.ToString, MsgBoxStyle.Information)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Private Sub BtnAddEmptyMacro_Click(sender As Object, e As RoutedEventArgs) Handles BtnAddEmptyMacro.Click
        Hide()
        Application.Current.RecordWindow.Show()
    End Sub
End Class
