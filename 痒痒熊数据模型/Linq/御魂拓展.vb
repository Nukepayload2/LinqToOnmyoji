Imports System.Runtime.CompilerServices

Public Module 御魂拓展

    <Extension>
    Public Function 种类(御魂 As 御魂) As 御魂种类
        Return 御魂.套装类型Id
    End Function

    <Extension>
    Public Function 名称(御魂 As 御魂) As String
        Dim 类型 As 御魂种类 = 御魂.套装类型Id
        If 御魂图鉴.收录了此类型的御魂(类型) Then
            Return 类型.ToString
        End If
        Return "未知"
    End Function

    <Extension>
    Public Function 创建御魂整理(御魂数据 As IReadOnlyList(Of 御魂)) As 御魂整理状态
        Return New 御魂整理状态(御魂数据)
    End Function

    <Extension>
    Public Function 属性分类(副属性 As 御魂副属性) As 御魂属性类型
        Return 属性分类(副属性.种类)
    End Function

    Private Function 属性分类(种类 As String) As 御魂属性类型
        Select Case 种类
            Case "AttackRate"
                Return 御魂属性类型.攻击加成
            Case "DefenseRate"
                Return 御魂属性类型.防御加成
            Case "HpRate"
                Return 御魂属性类型.生命加成
            Case "EffectHitRate"
                Return 御魂属性类型.效果命中
            Case "EffectResistRate"
                Return 御魂属性类型.效果抵抗
            Case "CritRate"
                Return 御魂属性类型.暴击
            Case "CritPower"
                Return 御魂属性类型.暴击伤害
            Case "Speed"
                Return 御魂属性类型.速度
            Case "Attack"
                Return 御魂属性类型.攻击
            Case "Defense"
                Return 御魂属性类型.防御
            Case "Hp"
                Return 御魂属性类型.生命
        End Select
        Throw New ArgumentException
    End Function

    <Extension>
    Public Function 属性分类(主属性 As 御魂主属性) As 御魂属性类型
        Return 属性分类(主属性.种类)
    End Function

    <Extension>
    Public Sub 弃置(御魂 As IEnumerable(Of 御魂))
        For Each s In 御魂
            s.已弃置 = True
        Next
    End Sub

    <Extension>
    Public Sub 恢复(御魂 As IEnumerable(Of 御魂))
        For Each s In 御魂
            s.已弃置 = False
        Next
    End Sub
End Module
