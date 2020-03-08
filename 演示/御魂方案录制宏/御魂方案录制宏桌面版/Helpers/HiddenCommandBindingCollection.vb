Imports System.ComponentModel

Public Class HiddenCommandBindingCollection
    Private ReadOnly _storage As New List(Of HiddenCommandBinding)
    Public Sub Add(target As INotifyPropertyChanged, propertyName As String, command As ICommand)
        Dim bind As New HiddenCommandBinding(target, propertyName, command)
        AddHandler target.PropertyChanged,
            Sub(sender, e)
                If e.PropertyName = bind.PropertyName Then
                    Dim tar = bind.Target
                    If command.CanExecute(tar) Then
                        command.Execute(tar)
                    End If
                End If
            End Sub
        _storage.Add(bind)
    End Sub
    Public Sub AddRange(targets As IEnumerable(Of INotifyPropertyChanged), propertyName As String, command As ICommand)
        For Each target In targets
            Add(target, propertyName, command)
        Next
    End Sub
End Class
