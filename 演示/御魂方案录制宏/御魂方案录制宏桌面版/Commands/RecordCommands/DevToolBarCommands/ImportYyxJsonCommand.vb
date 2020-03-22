Imports Microsoft.Win32
Imports Nukepayload2.Linq.Onmyoji

Public Class ImportYyxJsonCommand
    Inherits AsyncCommandBase

    Private ReadOnly _viewModel As RecordMacroViewModel

    Public Sub New(recordMacroViewModel As RecordMacroViewModel)
        _viewModel = recordMacroViewModel
    End Sub

    Private ReadOnly _openDataDialog As New OpenFileDialog With {
        .Filter = "JSON 文件|*.json"
    }

    Protected Overrides Function ExecuteAsync(parameter As Object) As Task
        If _openDataDialog.ShowDialog Then
            Dim yyxJsonFile = _openDataDialog.FileName
            Try
                Dim snap = 痒痒熊快照.加载Json文件(yyxJsonFile)
                _viewModel.YyxData = snap
                _viewModel.ViewingEquipments = snap.数据.御魂
            Catch ex As Exception
                _viewModel.YyxData = Nothing
                MsgBox(ex.Message, vbExclamation, "加载快照失败")
            End Try
        End If
        Return Task.CompletedTask
    End Function
End Class
