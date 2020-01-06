<Assembly: DisableDpiAwareness>

Class Application

    ' 应用程序级事件(例如 Startup、Exit 和 DispatcherUnhandledException)
    ' 可以在此文件中进行处理。

    Public Shared Shadows ReadOnly Property Current As Application
        Get
            Return System.Windows.Application.Current
        End Get
    End Property

    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        MainWindow = SplashWindow
        SplashWindow.Show()
    End Sub

End Class
