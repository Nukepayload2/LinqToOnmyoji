Class Application

    ' 应用程序级事件(例如 Startup、Exit 和 DispatcherUnhandledException)
    ' 可以在此文件中进行处理。

    Public Shared Shadows ReadOnly Property Current As Application
        Get
            Return System.Windows.Application.Current
        End Get
    End Property

    Private _codeWindow As CodeWindow

    Public ReadOnly Property CodeWindow As CodeWindow
        Get
            If _codeWindow Is Nothing Then
                _codeWindow = New CodeWindow
                AddHandler _codeWindow.Closed, AddressOf CodeWindowClosed
            End If

            Return _codeWindow
        End Get
    End Property

    Private Sub CodeWindowClosed(sender As Object, e As EventArgs)
        RemoveHandler _codeWindow.Closed, AddressOf CodeWindowClosed
        _codeWindow = Nothing
    End Sub

    Private _macrosWindow As MacrosWindow

    Public ReadOnly Property MacrosWindow As MacrosWindow
        Get
            If _macrosWindow Is Nothing Then
                _macrosWindow = New MacrosWindow
                AddHandler _macrosWindow.Closed, AddressOf MacrosWindowClosed
            End If

            Return _macrosWindow
        End Get
    End Property

    Private Sub MacrosWindowClosed(sender As Object, e As EventArgs)
        RemoveHandler _macrosWindow.Closed, AddressOf MacrosWindowClosed
        _macrosWindow = Nothing
    End Sub

End Class
