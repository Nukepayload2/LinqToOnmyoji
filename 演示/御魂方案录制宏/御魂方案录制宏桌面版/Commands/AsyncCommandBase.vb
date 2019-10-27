Public MustInherit Class AsyncCommandBase
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Dim _CanExecute As Boolean = True
    Private Property CanExec As Boolean
        Get
            Return _CanExecute
        End Get
        Set(value As Boolean)
            Dim raise = value <> _CanExecute
            _CanExecute = value
            If raise Then RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Async Sub Execute(parameter As Object) Implements ICommand.Execute
        CanExec = False
        Await ExecuteAsync(parameter)
        CanExec = True
    End Sub

    Protected MustOverride Async Function ExecuteAsync(parameter As Object) As Task

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return CanExec
    End Function
End Class
