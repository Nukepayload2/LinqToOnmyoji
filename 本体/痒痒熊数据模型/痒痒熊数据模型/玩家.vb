Public Class 玩家

    <JsonProperty("id"), JsonPropertyName("id")>
    Public Property Id As Integer

    <JsonProperty("level"), JsonPropertyName("level")>
    Public Property 等级 As Integer

    <JsonProperty("name"), JsonPropertyName("name")>
    Public Property 名称 As String

    <JsonProperty("server_id"), JsonPropertyName("server_id")>
    Public Property 服务器Id As Integer
End Class
