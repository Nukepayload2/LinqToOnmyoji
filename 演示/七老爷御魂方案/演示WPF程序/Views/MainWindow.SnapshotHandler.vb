Imports System.Text
Imports Nukepayload2.Csv
Imports Nukepayload2.Linq.Onmyoji
Imports Nukepayload2.Linq.Onmyoji.Utilities

Partial Class MainWindow

    Private _当前快照 As 痒痒熊快照
    Private _当前快照路径 As String

    Const IO错误提示 = "请检查文件是否被占用或者移动。
如果问题持续存在，请联系作者。"

    Private Shared ReadOnly Property 通用御魂整理错误提示 As String
        Get
            Return $"出现错误, 请检查拖放的文件是不是 {痒痒熊快照.已适配的产品和版本} 导出的。
如果问题持续存在或者痒痒熊导出器新版本的数据不工作，请联系作者。"
        End Get
    End Property

    Private Async Function 导入快照文件(输入文件 As String) As Task
        TxtOut.Text = String.Empty
        屏蔽按钮()

        Try
            If 输入文件 = Nothing OrElse Not IO.File.Exists(输入文件) Then
                TxtOut.AppendLine("文件格式不正确。")
                Return
            End If

            TxtOut.AppendLine("载入中...")
            Dim 快照 = Await Task.Run(Function() 痒痒熊快照.加载Json文件(输入文件))
            If 快照.版本未适配 Then
                TxtOut.AppendLine($"注意：本程序仅适配了{痒痒熊快照.已适配的产品和版本}，而这个文件的格式或者版本未经适配。")
            End If
            _当前快照 = 快照
            _当前快照路径 = 输入文件
            TblDataStatus.Text = 输入文件
            TxtOut.AppendLine("已加载快照。")
        Catch ex As IO.IOException
            TxtOut.AppendLine($"错误信息: {ex}")
            MsgBox(IO错误提示, vbExclamation, "错误")
        Catch ex As Exception
            TxtOut.AppendLine($"错误信息: {ex}")
            MsgBox(通用御魂整理错误提示, vbExclamation, "错误")
        Finally
            恢复按钮()
        End Try
    End Function

    Private Sub 恢复按钮()
        BtnFileDrop.IsEnabled = True
        BtnExportAMao.IsEnabled = True
        BtnExportLao7.IsEnabled = True
    End Sub

    Private Sub 屏蔽按钮()
        BtnFileDrop.IsEnabled = False
        BtnExportAMao.IsEnabled = False
        BtnExportLao7.IsEnabled = False
    End Sub

    Private Async Function 整理御魂(方案 As Action(Of 御魂整理宏示例)) As Task
        Dim 快照 = _当前快照
        If 快照 Is Nothing Then
            MsgBox("请先加载快照再整理御魂。", vbExclamation, "快照未加载")
            Return
        End If

        TxtOut.Text = String.Empty
        屏蔽按钮()

        Try
            Dim 御魂备份 = Aggregate e In 快照.数据.御魂 Select e.浅克隆 Into ToArray
            Dim 六星御魂 = From s In 御魂备份 Where s.星级 = 6 AndAlso s.已弃置 = False

            TxtOut.Text = String.Empty
            Dim 整理前未弃置御魂 = 六星御魂.ToDictionary(Function(s) s.Id, Function(s) s)
            Dim 整理前数量 = 整理前未弃置御魂.Count
            TxtOut.AppendLine($"整理前六星御魂数量: {整理前数量}")
            Await Task.Run(Sub() 方案(New 御魂整理宏示例(御魂备份)))
            Dim 整理后未弃置御魂 = 六星御魂.ToDictionary(Function(s) s.Id, Function(s) s)
            Dim 整理后数量 = 整理后未弃置御魂.Count
            TxtOut.AppendLine($"整理后六星御魂数量: {整理后数量}")
            If 整理后数量 > 整理前数量 Then
                TxtOut.AppendLine($"可能整理前弃置了胚子？")
            End If
            If MsgBox("是否保存弃置的御魂到 csv 文件中？可以稍后使用 Excel 等工具查看 csv 文件。",
                      vbQuestion Or vbYesNo, "保存报告") = vbYes Then
                Dim 输入文件 = _当前快照路径
                _saveDlg.FileName = IO.Path.GetFileNameWithoutExtension(输入文件) & ".csv"
                Await 保存数据Async(整理前未弃置御魂, 整理后未弃置御魂)
            End If
            TxtOut.AppendLine("已生成御魂整理结果。")
        Catch ex As IO.IOException
            TxtOut.AppendLine($"错误信息: {ex}")
            MsgBox(IO错误提示, vbExclamation, "错误")
        Catch ex As Exception
            TxtOut.AppendLine($"错误信息: {ex}")
            MsgBox(通用御魂整理错误提示, vbExclamation, "错误")
        Finally
            恢复按钮()
        End Try
    End Function

    Private Async Function 保存数据Async(
        整理前未弃置御魂 As Dictionary(Of String, 御魂),
        整理后未弃置御魂 As Dictionary(Of String, 御魂)) As Task

        If Not _saveDlg.ShowDialog Then
            Return
        End If

        Dim csvText = Await 御魂方案示例核心.Csv导出器.保存数据Async(整理前未弃置御魂, 整理后未弃置御魂)
        Dim outFileName = _saveDlg.FileName

        For Each encoding In s_encodings
            Dim 最终文件名 = outFileName
            If encoding IsNot Encoding.UTF8 Then
                最终文件名 = 添加编码名称(最终文件名, encoding)
            End If
            Await Task.Run(Sub() IO.File.WriteAllText(最终文件名, csvText, encoding))
        Next

        If MsgBox("文件已保存，是否打开? (如果乱码了请尝试手动打开与这个报告同时生成的文件)",
                   vbQuestion Or vbYesNo, "已保存") = vbYes Then
            Process.Start("explorer.exe", """" & outFileName & """")
        End If
    End Function

    Private ReadOnly s_encodings As Encoding() = {
        Encoding.UTF8, Encoding.GetEncoding("gb2312")
    }

    Private Function 添加编码名称(outFileName As String, encoding As Encoding) As String
        If Not outFileName Like "*?.csv" Then
            Return outFileName
        End If
        Dim leftPart = LeftRev(outFileName, ".csv".Length)
        Return leftPart & "_" & encoding.WebName & ".csv"
    End Function

    Private Function LeftRev(target As String, count As Integer) As String
        If count < 0 OrElse target Is Nothing Then
            Return target
        End If
        Return target.Substring(0, target.Length - count)
    End Function
End Class
