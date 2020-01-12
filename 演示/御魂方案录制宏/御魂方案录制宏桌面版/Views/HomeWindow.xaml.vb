Public Class HomeWindow

    Private Sub TitleBarDragElement_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles TitleBarDragElement.PreviewMouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        ShowAboutCommand.Instance.Execute(Nothing)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Private Sub BtnAddEmptyMacro_Click(sender As Object, e As RoutedEventArgs) Handles BtnAddEmptyMacro.Click
        Hide()
        Application.Current.RecordWindow.Show()
    End Sub

    Private Async Sub HomeWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Await Task.Delay(10)
        Try
            If Not My.Settings.IsLoaded Then
                Await Task.Run(AddressOf My.Settings.Load)
            End If
        Catch ex As Exception
        End Try
        Dim recentFile = My.Settings.RecentFiles
        LstRecentFiles.ItemsSource = recentFile
        If recentFile?.Count > 0 Then
            TblRecentHere.Visibility = Visibility.Collapsed
        End If
        PrgLoadRecent.IsIndeterminate = False
    End Sub
End Class
