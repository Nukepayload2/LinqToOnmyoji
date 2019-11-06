Class Application

    ' 应用程序级事件(例如 Startup、Exit 和 DispatcherUnhandledException)
    ' 可以在此文件中进行处理。

#If NETCORE3 Then
    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        Text.Encoding.RegisterProvider(Text.CodePagesEncodingProvider.Instance)
    End Sub
#End If

End Class
