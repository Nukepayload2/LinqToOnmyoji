Public Class 多重值过滤器(Of T)
    Inherits HashSet(Of T)

    Public Sub 选择(数值 As T)
        Add(数值)
    End Sub

    Public Sub 选择(ParamArray 数值 As T())
        For Each obj In 数值
            Add(obj)
        Next
    End Sub

    Public Sub 改为(数值 As T)
        重置()
        选择(数值)
    End Sub

    Public Sub 改为(ParamArray 数值 As T())
        重置()
        选择(数值)
    End Sub

    Public Sub 去掉(数值 As T)
        Remove(数值)
    End Sub

    Public Sub 去掉(ParamArray 数值 As T())
        For Each obj In 数值
            Remove(obj)
        Next
    End Sub

    Public Sub 重置()
        Clear()
    End Sub
End Class
