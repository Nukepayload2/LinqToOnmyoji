Imports System.ComponentModel
Imports Microsoft.Win32
Imports Nukepayload2.Linq.Onmyoji.Scripting

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
        RecordMacroViewModel.Instance.ActiveDocument = New 宏文档
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

    WithEvents LoadDocumentDialog As New OpenFileDialog With {.Filter = "宏文档 (xml 格式)|*.xml"}

    Private Sub BtnBrowse_Click(sender As Object, e As RoutedEventArgs) Handles BtnBrowse.Click
        LoadDocumentDialog.ShowDialog()
    End Sub

    Private Sub LoadDocumentDialog_FileOk(sender As Object, e As CancelEventArgs) Handles LoadDocumentDialog.FileOk
        Try
            Dim docFile = LoadDocumentDialog.FileName
            RecordMacroViewModel.Instance.ActiveDocument = 宏文档.打开文件(docFile)
            My.Settings.RecentFiles.Remove(docFile)
            My.Settings.RecentFiles.Insert(0, docFile)
        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "加载宏文档失败")
            Return
        End Try

        Hide()
        Application.Current.RecordWindow.Show()
    End Sub
End Class
