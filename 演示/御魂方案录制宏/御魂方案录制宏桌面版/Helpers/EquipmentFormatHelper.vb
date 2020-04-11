Imports System.Runtime.CompilerServices
Imports Nukepayload2.Linq.Onmyoji

Module EquipmentFormatHelper
    Private ReadOnly s_countFormat As String = "{0:N2}次"
    Private ReadOnly s_percentageFormat As String = "+{0:P2}"
    Private ReadOnly s_generalFormat As String = "+{0:N2}"

    <Extension>
    Function 数字格式(类型 As 御魂属性类型) As String
        Select Case 类型
            Case 御魂属性类型.攻击加成
                Return s_percentageFormat
            Case 御魂属性类型.防御加成
                Return s_percentageFormat
            Case 御魂属性类型.生命加成
                Return s_percentageFormat
            Case 御魂属性类型.效果命中
                Return s_percentageFormat
            Case 御魂属性类型.效果抵抗
                Return s_percentageFormat
            Case 御魂属性类型.暴击
                Return s_percentageFormat
            Case 御魂属性类型.暴击伤害
                Return s_percentageFormat
            Case Else
                Return s_generalFormat
        End Select
    End Function

    <Extension>
    Function 数字格式(随机属性 As 御魂随机属性强化比率) As String
        Return s_countFormat
    End Function
End Module
