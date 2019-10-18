Public Class 式神

    <JsonProperty("attrs"), JsonPropertyName("attrs")>
    Public Property 面板 As 面板属性

    <JsonProperty("awake"), JsonPropertyName("awake")>
    Public Property 觉醒 As Integer

    <JsonProperty("born"), JsonPropertyName("born")>
    Public Property 已召唤 As Integer

    <JsonProperty("equips"), JsonPropertyName("equips")>
    Public Property 装备 As String()

    <JsonProperty("exp"), JsonPropertyName("exp")>
    Public Property 经验 As Double

    <JsonProperty("hero_id"), JsonPropertyName("hero_id")>
    Public Property 种类Id As Integer

    <JsonProperty("id"), JsonPropertyName("id")>
    Public Property Id As String

    <JsonProperty("level"), JsonPropertyName("level")>
    Public Property 等级 As Integer

    <JsonProperty("lock"), JsonPropertyName("lock")>
    Public Property 锁定 As Boolean

    <JsonProperty("nick_name"), JsonPropertyName("nick_name")>
    Public Property 昵称 As String

    <JsonProperty("rarity"), JsonPropertyName("rarity")>
    Public Property 稀有度 As String

    <JsonProperty("skills"), JsonPropertyName("skills")>
    Public Property 技能 As 技能()

    <JsonProperty("star"), JsonPropertyName("star")>
    Public Property 星级 As Integer
End Class
