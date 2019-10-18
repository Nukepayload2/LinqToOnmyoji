Imports System.IO
Imports System.Text.Json

Public Class 痒痒熊快照

    <JsonPropertyName("data")>
    Public Property 数据 As 账号数据

    <JsonPropertyName("timestamp")>
    Public Property 时间 As String

    <JsonPropertyName("version")>
    Public Property 版本 As String

    Public Shared Function 加载Json二进制(文件 As Byte()) As 痒痒熊快照
        Return JsonSerializer.Deserialize(Of 痒痒熊快照)(文件)
    End Function

    Public Shared Function 加载Json文件流(文件 As Stream) As 痒痒熊快照
        Using sr As New StreamReader(文件)
            Return 加载Json文本(sr.ReadToEnd)
        End Using
    End Function

    ''' <summary>
    ''' 某些流只支持异步读而不支持同步读。此 API 支持那种情况。
    ''' </summary>
    Public Shared Async Function 异步加载Json文件流(文件 As Stream) As Task(Of 痒痒熊快照)
        Using sr As New StreamReader(文件)
            Return Await JsonSerializer.DeserializeAsync(Of 痒痒熊快照)(文件)
        End Using
    End Function

    Public Shared Function 加载Json文件(文件 As String) As 痒痒熊快照
        Return 加载Json二进制(File.ReadAllBytes(文件))
    End Function

    Public Shared Function 加载Json文本(文本 As String) As 痒痒熊快照
        Return JsonSerializer.Deserialize(Of 痒痒熊快照)(文本)
    End Function
End Class
