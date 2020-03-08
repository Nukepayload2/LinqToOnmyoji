Public Class HiddenCommandBinding
    Public Sub New(target As Object, propertyName As String, command As ICommand)
        Me.Target = target
        Me.PropertyName = propertyName
        Me.Command = command
    End Sub

    Public ReadOnly Property Target As Object
    Public ReadOnly Property PropertyName As String
    Public ReadOnly Property Command As ICommand
End Class
