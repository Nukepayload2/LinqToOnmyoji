Imports System.Runtime.CompilerServices

Public Module 御魂整理状态拓展

    ''' <summary>
    ''' (此 API 针对 C# 设计，在 VB 应当使用 <see langword="With"/> 语句) 对于不支持重复引用单个对象的编程语言，将对于 <see cref="御魂整理状态"/> 的重复引用转化为链式调用。
    ''' </summary>
    <Extension>
    Public Function 配置过滤器(御魂整理状态 As 御魂整理状态, 配置动作 As Action(Of 御魂整理状态)) As 御魂整理状态
        配置动作(御魂整理状态)
        Return 御魂整理状态
    End Function

    ''' <summary>
    ''' 重置过滤器。默认不重置整理视图(已弃置/待整理)，因为阴阳师三周年庆版本的 UI 不会这样做。
    ''' </summary>
    <Extension>
    Public Function 重置过滤器(御魂整理状态 As 御魂整理状态,
                          Optional 重置整理视图 As Boolean = False,
                          Optional 重置御魂种类 As Boolean = True) As 御魂整理状态
        With 御魂整理状态
            .主属性.Clear()
            .位置.Clear()
            .副属性有.Clear()
            .副属性条数 = 副属性条数.不限
            .副属性没有.Clear()
            If 重置整理视图 Then .在弃置御魂中查找 = False
            .星级.Clear()
            If 重置御魂种类 Then .种类.Clear()
        End With
        Return 御魂整理状态
    End Function

End Module
