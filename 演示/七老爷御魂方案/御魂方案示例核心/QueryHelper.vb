Imports System.Runtime.CompilerServices

Module QueryHelper

    Function 取属性数字格式(属性 As String) As String
        Const BinaryCompare = StringComparison.Ordinal
        If 属性.EndsWith("加成", BinaryCompare) OrElse
            属性.StartsWith("暴击", BinaryCompare) OrElse
            属性.StartsWith("效果", BinaryCompare) Then
            Return "P2"
        Else
            Return "N2"
        End If
    End Function

    <Extension>
    Function 取元素没有就返回空(Of T As Class)(arr As T(), index As Integer) As T
        If index < arr.Length Then
            Return arr(index)
        End If
        Return Nothing
    End Function

End Module
