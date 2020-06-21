Imports System.Runtime.CompilerServices

Public Module 御魂拓展

    <Extension>
    Public Function 种类(御魂 As 御魂) As 御魂种类
        Return 御魂.套装类型Id
    End Function

    <Extension>
    Public Function 种类中文名(御魂 As 御魂) As String
        Dim 类型 As 御魂种类 = 种类(御魂)
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
        Return 种类英文名转御魂属性类型(副属性.种类)
    End Function

    <Extension>
    Public Function 套装属性分类(条目 As 御魂图鉴条目) As 御魂属性类型
        Return 种类英文名转御魂属性类型(条目.属性类型)
    End Function

    Friend Function 种类英文名转御魂属性类型(种类英文名 As String) As 御魂属性类型
        Select Case 种类英文名
            Case 御魂属性类型英文名.攻击加成
                Return 御魂属性类型.攻击加成
            Case 御魂属性类型英文名.防御加成
                Return 御魂属性类型.防御加成
            Case 御魂属性类型英文名.生命加成
                Return 御魂属性类型.生命加成
            Case 御魂属性类型英文名.效果命中
                Return 御魂属性类型.效果命中
            Case 御魂属性类型英文名.效果抵抗
                Return 御魂属性类型.效果抵抗
            Case 御魂属性类型英文名.暴击
                Return 御魂属性类型.暴击
            Case 御魂属性类型英文名.暴击伤害
                Return 御魂属性类型.暴击伤害
            Case 御魂属性类型英文名.速度
                Return 御魂属性类型.速度
            Case 御魂属性类型英文名.攻击
                Return 御魂属性类型.攻击
            Case 御魂属性类型英文名.防御
                Return 御魂属性类型.防御
            Case 御魂属性类型英文名.生命
                Return 御魂属性类型.生命
        End Select
        Throw New ArgumentException
    End Function

    <Extension>
    Public Function 英文名(种类 As 御魂属性类型) As String
        Select Case 种类
            Case 御魂属性类型.攻击加成
                Return 御魂属性类型英文名.攻击加成
            Case 御魂属性类型.防御加成
                Return 御魂属性类型英文名.防御加成
            Case 御魂属性类型.生命加成
                Return 御魂属性类型英文名.生命加成
            Case 御魂属性类型.效果命中
                Return 御魂属性类型英文名.效果命中
            Case 御魂属性类型.效果抵抗
                Return 御魂属性类型英文名.效果抵抗
            Case 御魂属性类型.暴击
                Return 御魂属性类型英文名.暴击
            Case 御魂属性类型.暴击伤害
                Return 御魂属性类型英文名.暴击伤害
            Case 御魂属性类型.速度
                Return 御魂属性类型英文名.速度
            Case 御魂属性类型.攻击
                Return 御魂属性类型英文名.攻击
            Case 御魂属性类型.防御
                Return 御魂属性类型英文名.防御
            Case 御魂属性类型.生命
                Return 御魂属性类型英文名.生命
        End Select
        Throw New ArgumentException
    End Function

    <Extension>
    Public Function 属性分类(主属性 As 御魂主属性) As 御魂属性类型
        Return 种类英文名转御魂属性类型(主属性.种类)
    End Function

    <Extension>
    Public Function 属性分类(随机比率 As 御魂随机属性强化比率) As 御魂属性类型
        Return 种类英文名转御魂属性类型(随机比率.种类)
    End Function

    <Extension>
    Public Function 属性分类(固有属性 As 御魂单个属性) As 御魂属性类型
        Return 种类英文名转御魂属性类型(固有属性.种类)
    End Function

    <Extension>
    Public Sub 弃置(御魂 As IEnumerable(Of 御魂), Optional 弃置带锁的御魂 As Boolean = False)
        For Each s In 御魂
            If Not 弃置带锁的御魂 AndAlso s.已锁定 Then Continue For
            s.已弃置 = True
        Next
    End Sub

    <Extension>
    Public Sub 恢复(御魂 As IEnumerable(Of 御魂))
        For Each s In 御魂
            s.已弃置 = False
        Next
    End Sub

    <Extension>
    Public Function 位置从1开始(御魂 As 御魂) As Integer
        Return 御魂.位置从0开始 + 1
    End Function
End Module
