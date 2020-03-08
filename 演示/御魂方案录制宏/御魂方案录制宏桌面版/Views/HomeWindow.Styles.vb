Imports Nukepayload2.UI.Win32

Partial Public Class HomeWindow

    Private Sub MainWindow_SourceInitialized(sender As Object, e As EventArgs) Handles Me.SourceInitialized
        Dim windowCompositionFactory As New WindowCompositionFactory
        If Win32ApiInformation.IsWindowAcrylicApiPresent OrElse Win32ApiInformation.IsAeroGlassApiPresent Then
            ' Enable blur effect
            Dim composition = windowCompositionFactory.TryCreateForCurrentView
            If composition?.TrySetBlur(Me, True) Then
                ClientAreaMaster.Background = New SolidColorBrush(Color.FromArgb(&HCC, &H1F, &H7F, &HFF))
                ClientAreaDetail.Background = Brushes.White
                Background = Brushes.Transparent
            End If
        End If
    End Sub
End Class
