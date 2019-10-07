Imports System.IO

Public Class 痒痒熊快照

    <JsonProperty("data")>
    Public Property 数据 As 账号数据

    <JsonProperty("timestamp")>
    Public Property 时间 As String

    <JsonProperty("version")>
    Public Property 版本 As String

    Public Shared Function 加载Json文件流(文件 As Stream) As 痒痒熊快照
        Using sr As New StreamReader(文件)
            Return 加载Json文本(sr.ReadToEnd)
        End Using
    End Function

    Public Shared Async Function 异步加载Json文件流(文件 As Stream) As Task(Of 痒痒熊快照)
        Using sr As New StreamReader(文件)
            Return Await 异步加载Json文本(Await sr.ReadToEndAsync)
        End Using
    End Function

    Public Shared Function 加载Json文件(文件 As String) As 痒痒熊快照
        Return 加载Json文本(File.ReadAllText(文件))
    End Function

    Public Shared Async Function 异步加载Json文本(文本 As String) As Task(Of 痒痒熊快照)
        Return Await Task.Run(Function() JsonConvert.DeserializeObject(Of 痒痒熊快照)(文本))
    End Function

    Public Shared Function 加载Json文本(文本 As String) As 痒痒熊快照
        Return JsonConvert.DeserializeObject(Of 痒痒熊快照)(文本)
    End Function
End Class
