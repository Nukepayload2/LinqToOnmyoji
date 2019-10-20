<TestClass>
Public Class 御魂拓展测试

    <TestMethod>
    Sub 测试种类中文名()
        Dim 御魂 As New 御魂 With {.套装类型Id = 御魂种类.破势}
        Assert.AreEqual("破势", 御魂.种类中文名)
    End Sub

    <TestMethod>
    Sub 测试英文名()
        Dim 属性 = 御魂属性类型.暴击伤害
        Assert.AreEqual("CritPower", 属性.英文名)
    End Sub
End Class
