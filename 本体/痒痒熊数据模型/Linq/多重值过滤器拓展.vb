Imports System.Runtime.CompilerServices

Public Module 多重值过滤器拓展
    ''' <summary>
    ''' 按属性去掉御魂过滤器中的选项
    ''' </summary>
    <Extension>
    Sub 按属性去掉(御魂过滤器 As 多重值过滤器(Of 御魂种类), 属性 As 御魂属性类型)
        御魂过滤器.去掉(御魂图鉴.查找种类(属性))
    End Sub

    ''' <summary>
    ''' 按属性去掉御魂过滤器中的选项
    ''' </summary>
    <Extension>
    Sub 按属性去掉(御魂过滤器 As 多重值过滤器(Of 御魂种类), ParamArray 属性 As 御魂属性类型())
        御魂过滤器.去掉(御魂图鉴.查找种类(属性))
    End Sub

    ''' <summary>
    ''' 按属性选择御魂过滤器中的选项
    ''' </summary>
    <Extension>
    Sub 按属性选择(御魂过滤器 As 多重值过滤器(Of 御魂种类), 属性 As 御魂属性类型)
        御魂过滤器.选择(御魂图鉴.查找种类(属性))
    End Sub

    ''' <summary>
    ''' 按属性选择御魂过滤器中的选项
    ''' </summary>
    <Extension>
    Sub 按属性选择(御魂过滤器 As 多重值过滤器(Of 御魂种类), ParamArray 属性 As 御魂属性类型())
        御魂过滤器.选择(御魂图鉴.查找种类(属性))
    End Sub

    ''' <summary>
    ''' 将御魂过滤器改为指定属性的御魂集合
    ''' </summary>
    <Extension>
    Sub 按属性改为(御魂过滤器 As 多重值过滤器(Of 御魂种类), 属性 As 御魂属性类型)
        御魂过滤器.改为(御魂图鉴.查找种类(属性))
    End Sub

    ''' <summary>
    ''' 将御魂过滤器改为指定属性的御魂集合
    ''' </summary>
    <Extension>
    Sub 按属性改为(御魂过滤器 As 多重值过滤器(Of 御魂种类), ParamArray 属性 As 御魂属性类型())
        御魂过滤器.改为(御魂图鉴.查找种类(属性))
    End Sub
End Module
