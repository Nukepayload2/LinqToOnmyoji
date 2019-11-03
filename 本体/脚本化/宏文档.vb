Imports System.Collections.ObjectModel

''' <summary>
''' 描述录制时操作的影响
''' </summary>
Public Class 宏文档

    Public Property 名称 As String

    Public ReadOnly Property 宏列表 As New ObservableCollection(Of 宏过程)

    Public ReadOnly Property 可撤销行为 As New 带上限的集合(Of 宏录制操作行为)

    Public ReadOnly Property 可重做行为 As New 带上限的集合(Of 宏录制操作行为)

End Class
