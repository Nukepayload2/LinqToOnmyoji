Public Class PickEquipmentKindsCommand
    Inherits AsyncCommandBase

    Private ReadOnly _viewModel As RecordMacroViewModel

    Public Sub New(recordMacroViewModel As RecordMacroViewModel)
        _viewModel = recordMacroViewModel
    End Sub

    Protected Overrides Function ExecuteAsync(parameter As Object) As Task
        Throw New NotImplementedException()
    End Function
End Class
