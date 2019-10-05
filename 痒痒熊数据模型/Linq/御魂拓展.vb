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
End Module
