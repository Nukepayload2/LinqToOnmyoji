Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Nukepayload2.Linq.Onmyoji

<TestClass>
Public Class 御魂整理测试
    Private _快照 As 痒痒熊快照

    <TestInitialize>
    Sub Init()
        _快照 = 痒痒熊快照.加载Json文件("测试数据.json")
    End Sub

    <TestMethod>
    Sub 测试过滤防御加成类型()
        Dim 御魂 = _快照.数据.御魂
        With 御魂.创建御魂整理
            .种类.选择(御魂图鉴.查找种类(御魂属性类型.防御加成))
            .星级.选择(5)
            .全选.弃置
        End With

        Assert.IsFalse(
            Aggregate s In 御魂
            Where s.星级 = 5 AndAlso s.已弃置 = False AndAlso
                Not s.已锁定 AndAlso {
                御魂种类.雪幽魂, 御魂种类.招财猫, 御魂种类.反枕,
                御魂种类.日女巳时, 御魂种类.木魅, 御魂种类.珍珠, 御魂种类.魅妖
                }.Contains(s.种类)
            Into Any)
        Assert.IsTrue(
            Aggregate s In 御魂
            Where s.星级 = 5 AndAlso s.已弃置 = False AndAlso
                Not s.已锁定 AndAlso {
                    御魂种类.破势, 御魂种类.针女, 御魂种类.网切, 御魂种类.三味
                }.Contains(s.种类)
            Into Any)
    End Sub

    <TestMethod>
    Sub 测试过滤星级()
        Dim 御魂 = _快照.数据.御魂
        With 御魂.创建御魂整理
            .星级.选择(5)
            .全选.弃置
        End With

        Assert.IsFalse(Aggregate s In 御魂
                       Where s.星级 = 5 AndAlso s.已弃置 = False AndAlso Not s.已锁定
                       Into Any)
    End Sub

    <TestMethod>
    Sub 测试过滤条数()
        Dim 御魂 = _快照.数据.御魂
        With 御魂.创建御魂整理
            .副属性条数 = 副属性条数.两条
            .全选.弃置
        End With

        Assert.IsFalse(Aggregate s In 御魂
                       Where s.副属性.Length = 2 AndAlso s.已弃置 = False
                       Into Any)
    End Sub

    <TestMethod>
    Sub 测试过滤位置()
        Dim 御魂 = _快照.数据.御魂
        With 御魂.创建御魂整理
            .星级.选择(5)
            .位置.选择(2, 4, 6)
            .全选.弃置
        End With

        Assert.IsFalse(Aggregate s In 御魂
                       Where s.星级 = 5 AndAlso
                             (s.位置从1开始 = 2 OrElse
                              s.位置从1开始 = 4 OrElse
                              s.位置从1开始 = 6) AndAlso
                             s.已弃置 = False AndAlso Not s.已锁定
                       Into Any)
    End Sub

    <TestMethod>
    Sub 测试主属性()
        Dim 御魂 = _快照.数据.御魂
        With 御魂.创建御魂整理
            .主属性.选择(御魂属性类型.防御, 御魂属性类型.防御加成)
            .全选.弃置(弃置带锁的御魂:=True)
        End With

        Assert.IsFalse(Aggregate s In 御魂
                       Let 分类 = s.主属性.属性分类
                       Where (分类 = 御魂属性类型.防御加成 OrElse
                              分类 = 御魂属性类型.防御) AndAlso
                             s.已弃置 = False
                       Into Any)
    End Sub

    <TestMethod>
    Sub 测试主属性带锁()
        Dim 御魂 = _快照.数据.御魂
        With 御魂.创建御魂整理
            .主属性.选择(御魂属性类型.防御, 御魂属性类型.防御加成)
            .全选.弃置
        End With

        Assert.IsFalse(Aggregate s In 御魂
                       Let 分类 = s.主属性.属性分类
                       Where (分类 = 御魂属性类型.防御加成 OrElse
                              分类 = 御魂属性类型.防御) AndAlso
                             s.已弃置 = False AndAlso Not s.已锁定
                       Into Any)
    End Sub

    <TestMethod>
    Sub 测试副属性有()
        Dim 御魂 = _快照.数据.御魂
        With 御魂.创建御魂整理
            .副属性有.选择(御魂属性类型.防御, 御魂属性类型.防御加成)
            .全选.弃置
        End With

        Assert.IsFalse(Aggregate s In 御魂
                       Let 分类 = (From attr In s.副属性 Select attr.属性分类)
                       Where 分类.Contains(御魂属性类型.防御加成) AndAlso
                             分类.Contains(御魂属性类型.防御) AndAlso
                             s.已弃置 = False AndAlso Not s.已锁定
                       Into Any)
    End Sub

    <TestMethod>
    Sub 测试副属性没有()
        Dim 御魂 = _快照.数据.御魂
        With 御魂.创建御魂整理
            ' 这个号本身就弃置了一些御魂，先恢复一下
            .在弃置御魂中查找 = True
            .全选.恢复
            .在弃置御魂中查找 = False
            ' 然后再弃置没暴击也没爆伤的
            .副属性没有.选择(御魂属性类型.暴击, 御魂属性类型.暴击伤害)
            .全选.弃置
        End With

        Assert.IsFalse(Aggregate s In 御魂
                       Let 分类 = (From attr In s.副属性 Select attr.属性分类)
                       Where (分类.Contains(御魂属性类型.暴击) OrElse
                              分类.Contains(御魂属性类型.暴击伤害)) AndAlso
                             s.已弃置 = True
                       Into Any)
    End Sub
End Class
