<TestClass>
Public Class 御魂图鉴测试
    <TestMethod>
    Sub 测试收录了此类型的御魂()
        For Each 种类 As 御魂种类 In [Enum].GetValues(GetType(御魂种类))
            Assert.IsTrue(御魂图鉴.收录了此类型的御魂(种类), "应该收录御魂: " & 种类.ToString)
        Next
    End Sub

    <TestMethod>
    Sub 测试收录了此类型别名的御魂()
        For Each 种类 As 御魂种类 In [Enum].GetValues(GetType(御魂种类别名))
            Assert.IsTrue(御魂图鉴.收录了此类型的御魂(种类), "应该收录御魂: " & 种类.ToString)
        Next
    End Sub

    <TestMethod>
    Sub 测试未收录此类型的御魂()
        Assert.IsFalse(御魂图鉴.收录了此类型的御魂(-1), "不应该收录御魂: -1")
    End Sub

    <TestMethod>
    Sub 测试按类型查找()
        With 御魂图鉴.按类型查找(御魂种类.三味)
            Assert.AreEqual(御魂种类.三味.value__, .Id)
            Assert.AreEqual(0.15, .属性数值)
            Assert.AreEqual(御魂属性类型英文名.暴击, .属性类型)
        End With
    End Sub

    <TestMethod>
    Sub 测试按英文名查找()
        Dim 查到了结果 = False
        For Each 御魂 In 御魂图鉴.按套装属性英文名查找(御魂属性类型英文名.暴击)
            查到了结果 = True
            Assert.AreEqual(0.15, 御魂.属性数值)
            Assert.AreEqual(御魂属性类型英文名.暴击, 御魂.属性类型)
        Next
        Assert.IsTrue(查到了结果, "未能查询到暴击御魂")
    End Sub
End Class
