Public Class 面板属性

    <JsonProperty("attack")>
    Public Property 攻击 As 攻击

    <JsonProperty("crit_power")>
    Public Property 暴击伤害 As 暴击伤害

    <JsonProperty("crit_rate")>
    Public Property 暴击 As 暴击

    <JsonProperty("defense")>
    Public Property 防御 As 防御

    <JsonProperty("effect_hit_rate")>
    Public Property 效果命中 As Double

    <JsonProperty("effect_resist_rate")>
    Public Property 效果抵抗 As Double

    <JsonProperty("max_hp")>
    Public Property 生命 As 生命

    <JsonProperty("speed")>
    Public Property 速度 As 速度
End Class