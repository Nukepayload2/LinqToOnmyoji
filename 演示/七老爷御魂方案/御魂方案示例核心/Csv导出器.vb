Imports Nukepayload2.Csv
Imports Nukepayload2.Linq.Onmyoji

Public Class Csv导出器

    Public Shared Async Function 保存数据Async(
        整理前未弃置御魂 As Dictionary(Of String, 御魂),
        整理后未弃置御魂 As Dictionary(Of String, 御魂)) As Task(Of String)

        Dim 整理前未弃置Id = 整理前未弃置御魂.Keys.ToArray
        For Each id In 整理后未弃置御魂.Keys
            整理前未弃置御魂.Remove(id)
        Next
        For Each id In 整理前未弃置Id
            整理后未弃置御魂.Remove(id)
        Next

        Dim 弃置的御魂 = From 御魂 In 整理前未弃置御魂.Values Select (御魂, 操作:="弃置")
        Dim 恢复的御魂 = From 御魂 In 整理后未弃置御魂.Values Select (御魂, 操作:="恢复")

        Return Await 保存数据Async(弃置的御魂.Concat(恢复的御魂))
    End Function

    Private Shared Async Function 保存数据Async(
        待导出御魂 As IEnumerable(Of (御魂 As 御魂, 操作 As String))) As Task(Of String)

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

        Dim csvText = Await Task.Run(Function() CsvConvert.SerializeObject(存储数据.ToArray))
        Return csvText
    End Function

End Class
