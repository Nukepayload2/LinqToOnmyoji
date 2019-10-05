Imports Nukepayload2.Linq.Onmyoji

Module Program
    Sub Main()
        Dim 快照 = 痒痒熊快照.加载("测试数据.json")
        Dim eqId = Aggregate 御魂 In 快照.数据.御魂
                   Group By 御魂.名称 Into Group
                   Select 名称, Group.Count Into ToArray

        Console.WriteLine("eqId.Len=" & eqId.Length)
        For Each eq In eqId
            Console.WriteLine(eq)
        Next
    End Sub
End Module
