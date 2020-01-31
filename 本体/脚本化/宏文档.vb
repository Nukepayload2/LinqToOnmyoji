Imports System.Collections.ObjectModel

''' <summary>
''' 描述录制时操作的影响
''' </summary>
Public Class 宏文档

    ''' <summary>
    ''' 文档的
    ''' </summary>
    Public Property 信息 As 文档信息

    Public ReadOnly Property 宏列表 As New ObservableCollection(Of 宏过程)

    ''' <summary>
    ''' 保留的属性，不一定支持。
    ''' 提供宏文档的作者对文档信息和宏列表进行数字签名以降低篡改可能性的能力。
    ''' </summary>
    Public Property 数字签名 As 文档数字签名

    ''' <summary>
    ''' 文件中不保存，用于支持撤销功能。
    ''' </summary>
    Public ReadOnly Property 可撤销行为 As New 带上限的集合(Of 宏录制操作行为)

    ''' <summary>
    ''' 文件中不保存，用于支持重做功能。
    ''' </summary>
    Public ReadOnly Property 可重做行为 As New 带上限的集合(Of 宏录制操作行为)

    Public Shared Function 打开文件(recordFile As String) As 宏文档
        Throw New NotImplementedException()
    End Function
End Class
