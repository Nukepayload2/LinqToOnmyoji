''' <summary>
''' 保留的类型，不一定支持。
''' 提供宏文档的作者对文档进行数字签名以降低篡改可能性的能力。
''' </summary>
Public Class 文档数字签名
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property 文档信息哈希值 As String
    Public Property 所有宏过程哈希值 As String
    ''' <summary>
    ''' 目前只实现 sha-512 一种
    ''' </summary>
    Public Property 哈希算法 As String
    Public Property 公钥 As String
End Class
