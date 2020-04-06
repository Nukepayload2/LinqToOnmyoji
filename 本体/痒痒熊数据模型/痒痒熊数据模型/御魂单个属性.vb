''' <summary>
''' 通常指首领御魂的固有属性
''' </summary>
Public Class 御魂单个属性

    <JsonProperty("type"), JsonPropertyName("type")>
    Public Property 种类 As String

    <JsonProperty("value"), JsonPropertyName("value")>
    Public Property 数值 As Double
End Class
