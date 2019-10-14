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

            Dim 六星御魂 = From s In 快照.数据.御魂 Where s.星级 = 6 AndAlso s.已弃置 = False

            TxtOut.Text = String.Empty
            Dim 整理前未弃置御魂 = 六星御魂.ToDictionary(Function(s) s.Id, Function(s) s)
            TxtOut.AppendText($"整理前六星御魂数量: {六星御魂.Count}" & vbCrLf)
            Await Task.Run(Sub() 御魂整理方案.七老爷三周年庆御魂整理方案(快照))
            TxtOut.AppendText($"整理后六星御魂数量: {六星御魂.Count}" & vbCrLf)

            If MsgBox("是否保存弃置的御魂到 csv 文件中？可以稍后使用 Excel 等工具查看 csv 文件。",
                      vbQuestion Or vbYesNo, "保存报告") = vbYes Then
                Await 保存数据Async(整理前未弃置御魂, 六星御魂)
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

    Private Async Function 保存数据Async(整理前未弃置御魂 As Dictionary(Of String, 御魂), 六星御魂 As IEnumerable(Of 御魂)) As Task
        For Each s In 六星御魂
            整理前未弃置御魂.Remove(s.Id)
        Next

        Dim 存储数据 =
            From s In 整理前未弃置御魂.Values
            Let 副属性1 = s.副属性.取元素没有就返回空(0)?.属性分类.ToString,
                副属性2 = s.副属性.取元素没有就返回空(1)?.属性分类.ToString,
                副属性3 = s.副属性.取元素没有就返回空(2)?.属性分类.ToString,
                副属性4 = s.副属性.取元素没有就返回空(3)?.属性分类.ToString,
                主属性 = s.主属性.属性分类.ToString
            Select 种类 = s.种类中文名, s.星级,
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
            Await Task.Run(
            Sub()
                Dim csvText = Nukepayload2.Csv.CsvConvert.SerializeObject(存储数据.ToArray)
                IO.File.WriteAllText(outFileName, csvText, Text.Encoding.UTF8)
            End Sub)
            If MsgBox("文件已保存，是否打开?", vbQuestion Or vbYesNo, "已保存") = vbYes Then
                Process.Start("explorer.exe", """" & outFileName & """")
            End If
        End If
    End Function

End Class
