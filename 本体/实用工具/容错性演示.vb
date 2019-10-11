Imports Nukepayload2.Linq.Onmyoji.御魂种类
Imports Nukepayload2.Linq.Onmyoji.御魂属性类型
Imports Nukepayload2.Linq.Onmyoji.副属性条数

' 为了开启容错功能，你需要导入别名。这是为了不干扰原名与字符串之间的转换专门独立出来的。
' 如果你想做一个模板，建议导入容错用的类型。

Imports Nukepayload2.Linq.Onmyoji.御魂种类别名
Imports Nukepayload2.Linq.Onmyoji.御魂属性类型别名

Public NotInheritable Class 御魂整理方案
    ''' <summary>
    ''' 弃置五星御魂中瘸腿的和不含暴击+爆伤组合的
    ''' </summary>
    Public Shared Sub 整理五星御魂(快照 As 痒痒熊快照)
        With 快照.数据.御魂.创建御魂整理
            .星级.选择(5)
            .副属性条数 = 两条
            .全选.弃置
            .副属性条数 = 不限
            .副属性没有.选择(暴伤)
            .全选.弃置
            .副属性没有.改为(暴击)
            .全选.弃置
        End With
    End Sub

    ''' <summary>
    ''' 弃置六星御魂中瘸腿的和没暴击的地藏像
    ''' </summary>
    Public Shared Sub 挑地藏(快照 As 痒痒熊快照)
        With 快照.数据.御魂.创建御魂整理
            .星级.选择(6)
            .种类.选择(地藏)
            .副属性条数 = 两条
            .全选.弃置
            .副属性条数 = 不限
            .副属性没有.选择(暴击)
            .全选.弃置
        End With
    End Sub
End Class
