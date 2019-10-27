Imports Nukepayload2.Linq.Onmyoji.御魂种类
Imports Nukepayload2.Linq.Onmyoji.御魂属性类型
Imports Nukepayload2.Linq.Onmyoji.副属性条数

Public Class 御魂整理预设宏
    Inherits 御魂整理状态

    Public Sub New(御魂数据 As IReadOnlyList(Of 御魂))
        MyBase.New(御魂数据)
    End Sub

#Region "设计器的简要视图"
    Sub 宏1()
        星级.选择(5)
        副属性条数 = 两条
        全选.弃置
        副属性条数 = 不限
        副属性没有.选择(暴击伤害)
        全选.弃置
        副属性没有.改为(暴击)
        全选.弃置
    End Sub
#End Region

End Class
