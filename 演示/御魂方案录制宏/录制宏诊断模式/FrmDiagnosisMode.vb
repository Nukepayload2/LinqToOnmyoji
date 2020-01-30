Imports System.ComponentModel
Imports System.Reflection

Public Class FrmDiagnosisMode
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        RefreshAsmList()
    End Sub

    Private Sub RefreshAsmList()
        LstAsms.Items.Clear()
        Dim asms = AppDomain.CurrentDomain.GetAssemblies
        Dim ctls = From asm In asms
                   Select New ListViewItem({asm.FullName, asm.Location,
                       asm.GetCustomAttributes(Of AssemblyFileVersionAttribute).FirstOrDefault?.Version})

        LstAsms.Items.AddRange(ctls.ToArray)
    End Sub

    Private Sub FrmDiagnosisMode_Load(sender As Object, e As EventArgs) Handles Me.Load
        LstAsms.Columns.Add("全名", 300, HorizontalAlignment.Left)
        LstAsms.Columns.Add("文件路径", 400, HorizontalAlignment.Left)
        LstAsms.Columns.Add("文件版本", 100, HorizontalAlignment.Left)

        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CurrentDomain_AssemblyResolve
    End Sub

    Private Function CurrentDomain_AssemblyResolve(sender As Object, args As ResolveEventArgs) As Assembly
        If OpenAsmDialog.FileName = Nothing Then
            Return Nothing
        End If

        Dim targetDir = IO.Path.GetDirectoryName(OpenAsmDialog.FileName)
        Dim findName As New AssemblyName(args.Name)
        Dim findFileName = findName.Name

        Dim findFile = IO.Path.Combine(targetDir, findFileName)

        Dim findDll = findFile & ".dll"
        If IO.File.Exists(findDll) Then
            Return Assembly.LoadFile(findDll)
        End If

        Return Nothing
    End Function

    WithEvents OpenAsmDialog As New OpenFileDialog With {.Filter = ".NET Framework 程序|*.exe"}

    Private Sub BtnLaunch_Click(sender As Object, e As EventArgs) Handles BtnLaunch.Click
        OpenAsmDialog.ShowDialog()
    End Sub

    Private Sub OpenAsmDialog_FileOk(sender As Object, e As CancelEventArgs) Handles OpenAsmDialog.FileOk
        Try
            Dim asmName = OpenAsmDialog.FileName
            AppDomain.CurrentDomain.ExecuteAssembly(asmName)
            RefreshAsmList()
        Catch ex As Exception
            MsgBox(ex.ToString, vbExclamation, "错误")
        End Try
    End Sub
End Class
