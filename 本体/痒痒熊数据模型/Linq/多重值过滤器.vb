Public Class 多重值过滤器(Of T)
    Inherits HashSet(Of T)

    ''' <summary>
    ''' 增加指定的条件到现有过滤条件
    ''' </summary>
    Public Sub 选择(数值 As T)
        Add(数值)
    End Sub

    ''' <summary>
    ''' 增加指定的条件到现有过滤条件
    ''' </summary>
    Public Sub 选择(数值 As IEnumerable(Of T))
        For Each obj In 数值
            Add(obj)
        Next
    End Sub

    ''' <summary>
    ''' 增加指定的条件到现有过滤条件
    ''' </summary>
    Public Sub 选择(ParamArray 数值 As T())
        For Each obj In 数值
            Add(obj)
        Next
    End Sub

    ''' <summary>
    ''' 用指定的条件替换现有条件
    ''' </summary>
    Public Sub 改为(数值 As T)
        重置()
        选择(数值)
    End Sub

    ''' <summary>
    ''' 用指定的条件替换现有条件
    ''' </summary>
    Public Sub 改为(ParamArray 数值 As T())
        重置()
        选择(数值)
    End Sub

    ''' <summary>
    ''' 用指定的条件替换现有条件
    ''' </summary>
    Public Sub 改为(数值 As IEnumerable(Of T))
        重置()
        选择(数值)
    End Sub

    ''' <summary>
    ''' 从现有条件删除指定的条件
    ''' </summary>
    Public Sub 去掉(数值 As T)
        Remove(数值)
    End Sub

    ''' <summary>
    ''' 从现有条件删除指定的条件
    ''' </summary>
    Public Sub 去掉(ParamArray 数值 As T())
        For Each obj In 数值
            Remove(obj)
        Next
    End Sub

    ''' <summary>
    ''' 从现有条件删除指定的条件
    ''' </summary>
    Public Sub 去掉(数值 As IEnumerable(Of T))
        For Each obj In 数值
            Remove(obj)
        Next
    End Sub

    ''' <summary>
    ''' 删除所有条件
    ''' </summary>
    Public Sub 重置()
        Clear()
    End Sub
End Class
