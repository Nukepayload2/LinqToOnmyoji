Imports Microsoft.Win32
Imports Nukepayload2.Linq.Onmyoji.Scripting

Public Class ImportYyxJsonCommand
    Inherits AsyncCommandBase

    Private ReadOnly _viewModel As RecordMacroViewModel

    Public Sub New(recordMacroViewModel As RecordMacroViewModel)
        _viewModel = recordMacroViewModel
    End Sub

    Private ReadOnly _openDataDialog As New OpenFileDialog With {
        .Filter = "*.json|JSON 文件"
    }

    Protected Overrides Function ExecuteAsync(parameter As Object) As Task
        If _openDataDialog.ShowDialog Then
            Dim yyxJsonFile = _openDataDialog.FileName

        End If
        Return Task.CompletedTask
    End Function
End Class
