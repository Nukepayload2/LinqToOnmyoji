Imports System.IO
Imports System.Text.Json

Public Class 痒痒熊快照

    <JsonProperty("data"), JsonPropertyName("data")>
    Public Property 数据 As 账号数据

    <JsonProperty("timestamp"), JsonPropertyName("timestamp")>
    Public Property 时间 As String

    <JsonProperty("version"), JsonPropertyName("version")>
    Public Property 版本 As String

    Public ReadOnly Property 版本未适配 As Boolean
        Get
            Return 版本 <> "0.99.1"
        End Get
    End Property

    ''' <summary>
    ''' 痒痒熊快照 0.99.1
    ''' </summary>
    Public Shared ReadOnly Property 已适配的产品和版本 As String = "痒痒熊快照 0.99.1"

    ''' <summary>
    ''' 使用 <see cref="JsonSerializer"/> 加载痒痒熊快照。
    ''' 在 .NET Core 3.0 平台有卓越的性能，但是在 Blazor 上比较慢。
    ''' </summary>
    Public Shared Function 加载Json二进制(内容 As Byte()) As 痒痒熊快照
        Return JsonSerializer.Deserialize(Of 痒痒熊快照)(内容)
    End Function

    ''' <summary>
    ''' 使用 <see cref="JsonSerializer"/> 加载痒痒熊快照。
    ''' 在 .NET Core 3.0 平台有卓越的性能，但是在 Blazor 上比较慢。
    ''' </summary>
    Public Shared Function 加载Json文件(文件 As String) As 痒痒熊快照
        Return 加载Json二进制(File.ReadAllBytes(文件))
    End Function

    ''' <summary>
    ''' 使用 <see cref="JsonConvert"/> 加载痒痒熊快照。
    ''' 在 Blazor 比较快，在 .NET Core 3.0 明显比 <see cref="JsonSerializer"/> 慢。
    ''' </summary>
    Public Shared Function 加载Json文件流(文件 As Stream) As 痒痒熊快照
        Using sr As New StreamReader(文件)
            Return 加载Json文本(sr.ReadToEnd)
        End Using
    End Function

    ''' <summary>
    ''' 使用 <see cref="JsonConvert"/> 加载痒痒熊快照。针对只能异步读取的文件流设计。
    ''' 在 Blazor 比较快，在 .NET Core 3.0 明显比 <see cref="JsonSerializer"/> 慢。
    ''' </summary>
    Public Shared Async Function 异步加载Json文件流(文件 As Stream) As Task(Of 痒痒熊快照)
        Using sr As New StreamReader(文件)
            Return Await 异步加载Json文本(Await sr.ReadToEndAsync)
        End Using
    End Function

    ''' <summary>
    ''' 使用 <see cref="JsonConvert"/> 加载痒痒熊快照。
    ''' 在 Blazor 比较快，在 .NET Core 3.0 明显比 <see cref="JsonSerializer"/> 慢。
    ''' </summary>
    Public Shared Async Function 异步加载Json文本(文本 As String) As Task(Of 痒痒熊快照)
        Return Await Task.Run(Function() JsonConvert.DeserializeObject(Of 痒痒熊快照)(文本))
    End Function

    ''' <summary>
    ''' 使用 <see cref="JsonConvert"/> 加载痒痒熊快照。
    ''' 在 Blazor 比较快，在 .NET Core 3.0 明显比 <see cref="JsonSerializer"/> 慢。
    ''' </summary>
    Public Shared Function 加载Json文本(文本 As String) As 痒痒熊快照
        Return JsonConvert.DeserializeObject(Of 痒痒熊快照)(文本)
    End Function
End Class
