''' <summary>
''' 用于记录当前操作的信息
''' </summary>
Public Class 宏录制操作步骤信息
    ''' <summary>
    ''' 操作的类型
    ''' </summary>
    Public Property 操作 As 宏操作类型
    ''' <summary>
    ''' 参数
    ''' </summary>
    Public ReadOnly Property 参数 As New Dictionary(Of String, Object)
End Class
