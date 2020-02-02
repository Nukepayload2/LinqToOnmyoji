Class RecordWindow
    Private _viewModel As RecordMacroViewModel

    Private Sub RecordWindow_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Application.Current.HomeWindow.Show()
    End Sub

    Private Sub RecordWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        _viewModel = RecordMacroViewModel.Instance
        DataContext = _viewModel
    End Sub
End Class
