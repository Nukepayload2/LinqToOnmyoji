Class RecordWindow
    Private _viewModel As RecordMacroViewModel

    Private Sub RecordWindow_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FlyoutService.RemoveFlyoutHost()
        Application.Current.HomeWindow.Show()
    End Sub

    Private Sub RecordWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        _viewModel = RecordMacroViewModel.Instance
        DataContext = _viewModel
        FlyoutService.AddFlyoutHost(FlyoutHost)
    End Sub

    Private Sub RectFlyoutHostBack_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles RectFlyoutHostBack.MouseLeftButtonDown
        DragMove()
    End Sub
End Class
