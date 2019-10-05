Imports Nukepayload2.Linq.Onmyoji

Module Program
    Sub Main()
        Dim 快照 = 痒痒熊快照.加载Json文件("测试数据.json")
        Dim prim = From 御魂 In 快照.数据.御魂
                   Select 御魂.主属性.种类 Distinct

        Console.WriteLine(String.Join(vbCrLf, prim))
    End Sub

    Private Sub 每种御魂的数量(快照 As 痒痒熊快照)
        Dim eqId = Aggregate 御魂 In 快照.数据.御魂
                   Group By 御魂.名称 Into Group
                   Select 名称, Group.Count Into ToArray

        Console.WriteLine("eqId.Len=" & eqId.Length)
        For Each eq In eqId
            Console.WriteLine(eq)
        Next
    End Sub
End Module
