Public Class StopRecordMacroCommand
    Inherits AsyncCommandBase

    Private ReadOnly _viewModel As RecordMacroViewModel

    Public Sub New(recordMacroViewModel As RecordMacroViewModel)
        _viewModel = recordMacroViewModel
    End Sub

    Protected Overrides Function ExecuteAsync(parameter As Object) As Task
        _viewModel.IsRecording = False

        Return Task.CompletedTask
    End Function
End Class
