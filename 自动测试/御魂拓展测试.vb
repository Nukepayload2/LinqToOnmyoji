<TestClass>
Public Class 御魂拓展测试
    Private _快照 As 痒痒熊快照

    <TestInitialize>
    Sub Init()
        _快照 = 痒痒熊快照.加载Json文件("测试数据.json")
    End Sub

End Class
