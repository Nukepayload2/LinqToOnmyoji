Public Class 式神

    <JsonProperty("attrs")>
    Public Property 面板 As 面板属性

    <JsonProperty("awake")>
    Public Property 觉醒 As Integer

    <JsonProperty("born")>
    Public Property 已召唤 As Integer

    <JsonProperty("equips")>
    Public Property 装备 As String()

    <JsonProperty("exp")>
    Public Property 经验 As Double

    <JsonProperty("hero_id")>
    Public Property 种类Id As Integer

    <JsonProperty("id")>
    Public Property Id As String

    <JsonProperty("level")>
    Public Property 等级 As Integer

    <JsonProperty("lock")>
    Public Property 锁定 As Boolean

    <JsonProperty("nick_name")>
    Public Property 昵称 As String

    <JsonProperty("rarity")>
    Public Property 稀有度 As String

    <JsonProperty("skills")>
    Public Property 技能 As 技能()

    <JsonProperty("star")>
    Public Property 星级 As Integer
End Class
