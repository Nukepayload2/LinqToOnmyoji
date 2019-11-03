Imports System.Collections.ObjectModel

''' <summary>
''' 带数量上限和元素变更通知的集合
''' </summary>
Public Class 带上限的集合(Of T)
    Inherits ObservableCollection(Of T)

    Private _上限 As Integer = 100

    Public Property 上限 As Integer
        Get
            Return _上限
        End Get
        Set
            If Value <= 0 Then
                Throw New ArgumentOutOfRangeException
            End If
            _上限 = Value
        End Set
    End Property

    Public Function 弹出最后一个() As T
        Dim lastIndex = Count - 1
        If lastIndex < 0 Then
            Throw New InvalidOperationException("集合不包含任何元素，无法弹出。")
        End If

        弹出最后一个 = Me(lastIndex)
        RemoveAt(lastIndex)
    End Function

    Protected Overrides Sub InsertItem(index As Integer, item As T)
        If 上限 = Count Then
            RemoveAt(0)
        End If
        MyBase.InsertItem(index, item)
    End Sub
End Class
