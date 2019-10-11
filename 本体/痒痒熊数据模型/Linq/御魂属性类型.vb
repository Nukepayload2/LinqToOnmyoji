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
End Enum

''' <summary>
''' 御魂属性类型的常见简称或者拼错形式
''' </summary>
Public Enum 御魂属性类型别名
    <Obsolete("改用 效果抵抗")>
    抵抗 = 御魂属性类型.效果抵抗
    <Obsolete("改用 效果命中")>
    命中 = 御魂属性类型.效果命中
    <Obsolete("改用 效果命中")>
    效命 = 御魂属性类型.效果命中
    <Obsolete("改用 暴击伤害")>
    暴伤 = 御魂属性类型.暴击伤害
    <Obsolete("改用 暴击伤害")>
    爆伤 = 御魂属性类型.暴击伤害
    <Obsolete("改用 暴击")>
    爆击 = 御魂属性类型.暴击
End Enum
