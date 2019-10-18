Public Class 面板属性

    <JsonProperty("attack"), JsonPropertyName("attack")>
    Public Property 攻击 As 攻击和加成

    <JsonProperty("crit_power"), JsonPropertyName("crit_power")>
    Public Property 暴击伤害 As 暴击伤害和加成

    <JsonProperty("crit_rate"), JsonPropertyName("crit_rate")>
    Public Property 暴击 As 暴击和加成

    <JsonProperty("defense"), JsonPropertyName("defense")>
    Public Property 防御 As 防御和加成

    <JsonProperty("effect_hit_rate"), JsonPropertyName("effect_hit_rate")>
    Public Property 效果命中 As Double

    <JsonProperty("effect_resist_rate"), JsonPropertyName("effect_resist_rate")>
    Public Property 效果抵抗 As Double

    <JsonProperty("max_hp"), JsonPropertyName("max_hp")>
    Public Property 生命 As 生命和加成

    <JsonProperty("speed"), JsonPropertyName("speed")>
    Public Property 速度 As 速度和加成
End Class