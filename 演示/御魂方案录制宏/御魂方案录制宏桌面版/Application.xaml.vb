Imports Nukepayload2.Linq.Onmyoji.Scripting

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
        MainWindow = HomeWindow
        Dim args = Environment.GetCommandLineArgs
        If args.Length > 1 Then
            Dim recordFile = args(1)
            Try
                RecordMacroViewModel.Instance.ActiveDocument = 宏文档.打开文件(recordFile)
                RecordWindow.Show()
            Catch ex As Exception
                MsgBox(ex.Message, vbExclamation, "宏文档打开失败")
                HomeWindow.Show()
            End Try
        Else
            HomeWindow.Show()
        End If
    End Sub

    Private Sub Application_Exit(sender As Object, e As ExitEventArgs) Handles Me.[Exit]
        Try
            My.Settings.Save()
        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "保存设置失败")
        End Try
    End Sub
End Class
