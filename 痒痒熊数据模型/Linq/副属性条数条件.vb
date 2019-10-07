Public NotInheritable Class 副属性条数
    Public Shared ReadOnly 不足两条 As Func(Of Integer, Boolean) = Function(n) n < 2
    Public Shared ReadOnly 两条 As Func(Of Integer, Boolean) = Function(n) n = 2
    Public Shared ReadOnly 三条 As Func(Of Integer, Boolean) = Function(n) n = 3
    Public Shared ReadOnly 三条或更多 As Func(Of Integer, Boolean) = Function(n) n >= 3
    Public Shared ReadOnly 四条 As Func(Of Integer, Boolean) = Function(n) n = 4
    Public Shared ReadOnly 不限 As Func(Of Integer, Boolean)
End Class
