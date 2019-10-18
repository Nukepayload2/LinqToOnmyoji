Public Class 结界卡

    <JsonProperty("attrs"), JsonPropertyName("attrs")>
    Public Property 属性 As 结界卡属性

    <JsonProperty("id"), JsonPropertyName("id")>
    Public Property Id As String

    <JsonProperty("item_id"), JsonPropertyName("item_id")>
    Public Property 物品Id As Integer

    <JsonProperty("total_time"), JsonPropertyName("total_time")>
    Public Property 持续时间 As Integer
End Class
