Public Class 面板属性

    <JsonPropertyName("attack")>
    Public Property 攻击 As 攻击和加成

    <JsonPropertyName("crit_power")>
    Public Property 暴击伤害 As 暴击伤害和加成

    <JsonPropertyName("crit_rate")>
    Public Property 暴击 As 暴击和加成

    <JsonPropertyName("defense")>
    Public Property 防御 As 防御和加成

    <JsonPropertyName("effect_hit_rate")>
    Public Property 效果命中 As Double

    <JsonPropertyName("effect_resist_rate")>
    Public Property 效果抵抗 As Double

    <JsonPropertyName("max_hp")>
    Public Property 生命 As 生命和加成

    <JsonPropertyName("speed")>
    Public Property 速度 As 速度和加成
End Class