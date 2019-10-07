Imports Nukepayload2.Linq.Onmyoji

Module Program
    Sub Main()
        Dim 快照 = 痒痒熊快照.加载Json文件("测试数据.json")
        Dim 五星御魂 =
            From s In 快照.数据.御魂 Where s.星级 = 5 AndAlso s.已弃置 = False
        Console.WriteLine($"整理前五星御魂数量: {五星御魂.Count}")
        清理五星御魂(快照)
        Console.WriteLine($"整理后五星御魂数量: {五星御魂.Count}")
    End Sub

    Private Sub 清理五星御魂(快照 As 痒痒熊快照)
        With 快照.数据.御魂.创建御魂整理
            .星级.选择(5)
            .副属性条数 = 副属性条数.两条
            .全选.弃置
            .副属性条数 = 副属性条数.不限
            .副属性没有.选择(御魂属性类型.暴击伤害)
            .全选.弃置
            .副属性没有.改为(御魂属性类型.暴击)
            .全选.弃置
        End With
    End Sub
End Module
