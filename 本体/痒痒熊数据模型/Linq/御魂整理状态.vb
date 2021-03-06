﻿Public Class 御魂整理状态
    Public Property 御魂数据 As IReadOnlyList(Of 御魂)

    Public Sub New(御魂数据 As IReadOnlyList(Of 御魂))
        Me.御魂数据 = 御魂数据
    End Sub

    Sub New()

    End Sub

    ''' <summary>
    ''' 代表是否切换到已弃置御魂的画面。默认情况下在待整理御魂的画面。
    ''' </summary>
    Public Property 在弃置御魂中查找 As Boolean
    ''' <summary>
    ''' 御魂种类选中的御魂
    ''' </summary>
    Public ReadOnly Property 种类 As New 多重值过滤器(Of 御魂种类)
    ''' <summary>
    ''' 1 到 6 号位
    ''' </summary>
    Public ReadOnly Property 位置 As New 多重值过滤器(Of Integer)
    ''' <summary>
    ''' 1 到 6 星
    ''' </summary>
    Public ReadOnly Property 星级 As New 多重值过滤器(Of Integer)
    ''' <summary>
    ''' 主属性选中的。需要具备其中一种。
    ''' </summary>
    Public ReadOnly Property 主属性 As New 多重值过滤器(Of 御魂属性类型)
    ''' <summary>
    ''' 副属性画圈的。这些属性必须都具备。
    ''' </summary>
    Public ReadOnly Property 副属性有 As New 多重值过滤器(Of 御魂属性类型)
    ''' <summary>
    ''' 副属性打叉的。这些属性一个都不能具备。
    ''' </summary>
    Public ReadOnly Property 副属性没有 As New 多重值过滤器(Of 御魂属性类型)
    ''' <summary>
    ''' 副属性几条的过滤表达式。预设的条件在 <see cref="Onmyoji.副属性条数"/> 定义。
    ''' </summary>
    Public Property 副属性条数 As Func(Of Integer, Boolean)

    ''' <summary>
    ''' 从御魂数据中过滤御魂。
    ''' </summary>
    ''' <returns>御魂过滤结果</returns>
    Public Function 全选() As IEnumerable(Of 御魂)
        If 御魂数据 Is Nothing Then
            Return Enumerable.Empty(Of 御魂)
        End If
        全选 = From s In 御魂数据 Where s.已弃置 = 在弃置御魂中查找
        If 种类.Any Then
            全选 = From s In 全选 Where 种类.Contains(s.种类)
        End If
        If 位置.Any Then
            全选 = From s In 全选 Where 位置.Contains(s.位置从0开始 + 1)
        End If
        If 星级.Any Then
            全选 = From s In 全选 Where 星级.Contains(s.星级)
        End If
        If 主属性.Any Then
            全选 = From s In 全选 Where 主属性.Contains(s.主属性.属性分类)
        End If
        If 副属性有.Any Then
            ' 副属性带圈的意思是这些属性都要具备
            全选 = From s In 全选
                 Where 副属性有.All(Function(副属性) Aggregate prop In s.副属性 Where prop.属性分类 = 副属性 Into Any)
        End If
        If 副属性没有.Any Then
            ' 副属性带叉的意思是这些属性都不能具备
            全选 = From s In 全选
                 Where Not s.副属性.Any(Function(副属性) 副属性没有.Contains(副属性.属性分类))
        End If
        If 副属性条数 IsNot Nothing Then
            全选 = From s In 全选 Where 副属性条数(s.副属性.Length)
        End If
    End Function
End Class
