Imports System.ComponentModel

Class MainWindow

    Private WithEvents OpenDlg As New Microsoft.Win32.OpenFileDialog With {
        .Filter = "Json 文件|*.json"
    }

    Private ReadOnly _saveDlg As New Microsoft.Win32.SaveFileDialog With {
        .Filter = "Csv 文件|*.csv"
    }

    Private Async Sub BtnFileDrop_Drop(sender As Object, e As DragEventArgs) Handles BtnFileDrop.Drop
        Dim 输入文件 = TryCast(e.Data.GetData(DataFormats.FileDrop), String())?.FirstOrDefault
        Await 处理快照文件(输入文件)
    End Sub

    Private Sub BdrFileDrop_DragEnter(sender As Object, e As DragEventArgs) Handles BtnFileDrop.DragEnter
        e.Effects = DragDropEffects.Link
    End Sub

    Private Sub BtnFileDrop_Click(sender As Object, e As RoutedEventArgs) Handles BtnFileDrop.Click
        OpenDlg.ShowDialog()
    End Sub

    Private Async Sub OpenDlg_FileOk(sender As Object, e As CancelEventArgs) Handles OpenDlg.FileOk
        Await 处理快照文件(OpenDlg.FileName)
    End Sub
End Class
