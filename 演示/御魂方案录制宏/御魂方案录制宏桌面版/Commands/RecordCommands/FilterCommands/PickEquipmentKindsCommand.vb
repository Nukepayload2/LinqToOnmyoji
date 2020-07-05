Imports System.Windows.Interop

Public Class PickEquipmentKindsCommand
    Inherits AsyncCommandBase

    Private ReadOnly _viewModel As RecordMacroViewModel

    Public Sub New(recordMacroViewModel As RecordMacroViewModel)
        _viewModel = recordMacroViewModel
    End Sub

    Protected Overrides Async Function ExecuteAsync(parameter As Object) As Task
        Dim picker As New EquipmentPickerFlyout
        Dim yyxData = _viewModel.YyxData
        Dim equip = yyxData?.数据.御魂
        Dim result = Await picker.ShowAsync(equip)

    End Function
End Class
