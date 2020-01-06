Partial Public Class Application

#Region "CodeWindow 窗口的单实例管理"
    Private _codeWindow As CodeWindow

    ''' <summary>
    ''' "Visual Basic" 按钮点了之后出的窗口
    ''' </summary>
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
#End Region

#Region "MacrosWindow 窗口的单实例管理"
    Private _macrosWindow As MacrosWindow

    ''' <summary>
    ''' "宏" 按钮点了之后出的窗口
    ''' </summary>
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
#End Region

#Region "RecordWindow 窗口的单实例管理"
    Private _recordWindow As RecordWindow

    ''' <summary>
    ''' 录制宏的窗口
    ''' </summary>
    Public ReadOnly Property RecordWindow As RecordWindow
        Get
            If _recordWindow Is Nothing Then
                _recordWindow = New RecordWindow
                AddHandler _recordWindow.Closed, AddressOf RecordWindowClosed
            End If

            Return _recordWindow
        End Get
    End Property

    Private Sub RecordWindowClosed(sender As Object, e As EventArgs)
        RemoveHandler _recordWindow.Closed, AddressOf RecordWindowClosed
        _recordWindow = Nothing
    End Sub
#End Region

#Region "SplashWindow 窗口的单实例管理"
    Private _splashWindow As SplashWindow

    ''' <summary>
    ''' 应用程序的初始窗口
    ''' </summary>
    Public ReadOnly Property SplashWindow As SplashWindow
        Get
            If _splashWindow Is Nothing Then
                _splashWindow = New SplashWindow
                AddHandler _splashWindow.Closed, AddressOf SplashWindowClosed
            End If

            Return _splashWindow
        End Get
    End Property

    Private Sub SplashWindowClosed(sender As Object, e As EventArgs)
        RemoveHandler _splashWindow.Closed, AddressOf SplashWindowClosed
        _splashWindow = Nothing
    End Sub
#End Region

End Class
