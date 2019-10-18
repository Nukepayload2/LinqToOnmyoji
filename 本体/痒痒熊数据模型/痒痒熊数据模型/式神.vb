Public Class 式神

    <JsonPropertyName("attrs")>
    Public Property 面板 As 面板属性

    <JsonPropertyName("awake")>
    Public Property 觉醒 As Integer

    <JsonPropertyName("born")>
    Public Property 已召唤 As Integer

    <JsonPropertyName("equips")>
    Public Property 装备 As String()

    <JsonPropertyName("exp")>
    Public Property 经验 As Double

    <JsonPropertyName("hero_id")>
    Public Property 种类Id As Integer

    <JsonPropertyName("id")>
    Public Property Id As String

    <JsonPropertyName("level")>
    Public Property 等级 As Integer

    <JsonPropertyName("lock")>
    Public Property 锁定 As Boolean

    <JsonPropertyName("nick_name")>
    Public Property 昵称 As String

    <JsonPropertyName("rarity")>
    Public Property 稀有度 As String

    <JsonPropertyName("skills")>
    Public Property 技能 As 技能()

    <JsonPropertyName("star")>
    Public Property 星级 As Integer
End Class
