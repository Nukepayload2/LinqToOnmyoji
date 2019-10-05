Public Class 痒痒熊快照

    <JsonProperty("data")>
    Public Property 数据 As 账号数据

    <JsonProperty("timestamp")>
    Public Property 时间 As String

    <JsonProperty("version")>
    Public Property 版本 As String

    Public Shared Function 加载Json文件(文件 As String) As 痒痒熊快照
        Return JsonConvert.DeserializeObject(Of 痒痒熊快照)(IO.File.ReadAllText(文件))
    End Function
End Class
