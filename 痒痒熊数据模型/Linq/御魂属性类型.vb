Imports System.ComponentModel

Public Enum 御魂属性类型
    ''' <summary>
    ''' AttackRate
    ''' </summary>
    攻击加成
    ''' <summary>
    ''' DefenseRate
    ''' </summary>
    防御加成
    ''' <summary>
    ''' HpRate
    ''' </summary>
    生命加成
    ''' <summary>
    ''' EffectHitRate
    ''' </summary>
    效果命中
    ''' <summary>
    ''' EffectResistRate
    ''' </summary>
    效果抵抗
    ''' <summary>
    ''' CritRate
    ''' </summary>
    暴击
    ''' <summary>
    ''' CritPower
    ''' </summary>
    暴击伤害
    ''' <summary>
    ''' Speed
    ''' </summary>
    速度
    ''' <summary>
    ''' Attack
    ''' </summary>
    攻击
    ''' <summary>
    ''' Defense
    ''' </summary>
    防御
    ''' <summary>
    ''' Hp
    ''' </summary>
    生命

    ' 常见的拼错应该允许通过编译，但是在发布版本应该更正。
    <EditorBrowsable(EditorBrowsableState.Never)>
    <Obsolete("改用 效果抵抗")>
    抵抗 = 效果抵抗
    <EditorBrowsable(EditorBrowsableState.Never)>
    <Obsolete("改用 效果命中")>
    命中 = 效果命中
    <EditorBrowsable(EditorBrowsableState.Never)>
    <Obsolete("改用 效果命中")>
    效命 = 效果命中
    <EditorBrowsable(EditorBrowsableState.Never)>
    <Obsolete("改用 暴击伤害")>
    暴伤 = 暴击伤害
End Enum
