Imports Nukepayload2.Linq.Onmyoji.Utilities

<TestClass>
Public Class 御魂方案稳定性测试
    Private _快照 As 痒痒熊快照

    <TestInitialize>
    Sub Init()
        _快照 = 痒痒熊快照.加载Json文件("测试数据.json")
    End Sub

    <TestMethod>
    Sub 七老爷()
        Dim 六星御魂 = From s In _快照.数据.御魂 Where s.星级 = 6 AndAlso s.已弃置 = False
        Assert.AreEqual(2654, 六星御魂.Count)
        Dim 方案 As New 御魂整理宏示例(_快照)
        方案.七老爷三周年庆御魂整理方案()
        Assert.AreEqual(1465, 六星御魂.Count)
    End Sub

    <TestMethod>
    Sub 阿毛酱()
        Dim 六星御魂 = From s In _快照.数据.御魂 Where s.星级 = 6 AndAlso s.已弃置 = False
        Assert.AreEqual(2654, 六星御魂.Count)
        Dim 方案 As New 御魂整理宏示例(_快照)
        方案.阿毛缘结神版本御魂整理方案()
        Assert.AreEqual(1775, 六星御魂.Count)
    End Sub
End Class
