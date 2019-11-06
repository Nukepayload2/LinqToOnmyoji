Imports System.Text
Imports Nukepayload2.Csv
Imports Nukepayload2.Linq.Onmyoji
Imports Nukepayload2.Linq.Onmyoji.Utilities

Partial Class MainWindow

    Private Async Function 处理快照文件(输入文件 As String) As Task
        TxtOut.Text = String.Empty
        BtnFileDrop.IsEnabled = False
        Try
            If 输入文件 = Nothing OrElse Not IO.File.Exists(输入文件) Then
                TxtOut.AppendText("需要拖放痒痒熊快照 Json 文件" & vbCrLf)
                Return
            End If

            TxtOut.AppendText("载入中..." & vbCrLf)
            Dim 快照 = Await Task.Run(Function() 痒痒熊快照.加载Json文件(输入文件))
            If 快照.版本未适配 Then
                TxtOut.AppendText($"注意：本程序仅适配了{痒痒熊快照.已适配的产品和版本}，而这个文件的格式或者版本未经适配。" & vbCrLf)
            End If
            Dim 六星御魂 = From s In 快照.数据.御魂 Where s.星级 = 6 AndAlso s.已弃置 = False

            TxtOut.Text = String.Empty
            Dim 整理前未弃置御魂 = 六星御魂.ToDictionary(Function(s) s.Id, Function(s) s)
            Dim 整理前数量 = 整理前未弃置御魂.Count
            TxtOut.AppendText($"整理前六星御魂数量: {整理前数量}" & vbCrLf)
            Await Task.Run(Sub() 御魂整理方案.七老爷三周年庆御魂整理方案(快照))
            Dim 整理后未弃置御魂 = 六星御魂.ToDictionary(Function(s) s.Id, Function(s) s)
            Dim 整理后数量 = 整理后未弃置御魂.Count
            TxtOut.AppendText($"整理后六星御魂数量: {整理后数量}" & vbCrLf)
            If 整理后数量 > 整理前数量 Then
                TxtOut.AppendText($"可能整理前弃置了胚子？" & vbCrLf)
            End If
            If MsgBox("是否保存弃置的御魂到 csv 文件中？可以稍后使用 Excel 等工具查看 csv 文件。",
                      vbQuestion Or vbYesNo, "保存报告") = vbYes Then
                _saveDlg.FileName = IO.Path.GetFileNameWithoutExtension(输入文件) & ".csv"
                Await 保存数据Async(整理前未弃置御魂, 整理后未弃置御魂, 六星御魂)
            End If
            TxtOut.AppendText("操作成功完成。")
        Catch ex As IO.IOException
            TxtOut.AppendText($"错误信息: {ex}")
            MsgBox($"请检查文件是否被占用或者移动。
如果问题持续存在，请联系作者。", vbExclamation, "错误")
        Catch ex As Exception
            TxtOut.AppendText($"错误信息: {ex}")
            MsgBox($"出现错误, 请检查拖放的文件是不是痒痒熊快照 0.99.1 导出的。
如果问题持续存在或者痒痒熊导出器新版本的数据不工作，请联系作者。", vbExclamation, "错误")
        Finally
            BtnFileDrop.IsEnabled = True
        End Try
    End Function

    Private Async Function 保存数据Async(整理前未弃置御魂 As Dictionary(Of String, 御魂), 整理后未弃置御魂 As Dictionary(Of String, 御魂), 六星御魂 As IEnumerable(Of 御魂)) As Task
        Dim 整理前未弃置Id = 整理前未弃置御魂.Keys.ToArray
        For Each id In 整理后未弃置御魂.Keys
            整理前未弃置御魂.Remove(id)
        Next
        For Each id In 整理前未弃置Id
            整理后未弃置御魂.Remove(id)
        Next

        Dim 弃置的御魂 = From 御魂 In 整理前未弃置御魂.Values Select (御魂, 操作:="弃置")
        Dim 恢复的御魂 = From 御魂 In 整理后未弃置御魂.Values Select (御魂, 操作:="恢复")

        Await 保存数据Async(弃置的御魂.Concat(恢复的御魂))
    End Function

    Private ReadOnly s_encodings As Encoding() = {
        Encoding.UTF8, Encoding.GetEncoding("gb2312")
    }

    Private Async Function 保存数据Async(待导出御魂 As IEnumerable(Of (御魂 As 御魂, 操作 As String))) As Task
        Dim 存储数据 =
            From grp In 待导出御魂
            Let s = grp.御魂
            Let 副属性1 = s.副属性.取元素没有就返回空(0)?.属性分类.ToString,
                副属性2 = s.副属性.取元素没有就返回空(1)?.属性分类.ToString,
                副属性3 = s.副属性.取元素没有就返回空(2)?.属性分类.ToString,
                副属性4 = s.副属性.取元素没有就返回空(3)?.属性分类.ToString,
                主属性 = s.主属性.属性分类.ToString
            Select grp.操作, 种类 = s.种类中文名, s.星级,
                   s.等级, 位置 = s.位置从1开始,
                   主属性,
                   主属性数值 = s.主属性.数值.ToString(取属性数字格式(主属性)),
                   副属性1,
                   副属性1数值 = s.副属性.取元素没有就返回空(0)?.数值.ToString(取属性数字格式(副属性1)),
                   副属性2,
                   副属性2数值 = s.副属性.取元素没有就返回空(1)?.数值.ToString(取属性数字格式(副属性2)),
                   副属性3,
                   副属性3数值 = s.副属性.取元素没有就返回空(2)?.数值.ToString(取属性数字格式(副属性3)),
                   副属性4,
                   副属性4数值 = s.副属性.取元素没有就返回空(3)?.数值.ToString(取属性数字格式(副属性4))

        If _saveDlg.ShowDialog Then
            Dim outFileName = _saveDlg.FileName

            Dim csvText = Await Task.Run(Function() CsvConvert.SerializeObject(存储数据.ToArray))

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
        End If
    End Function

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
