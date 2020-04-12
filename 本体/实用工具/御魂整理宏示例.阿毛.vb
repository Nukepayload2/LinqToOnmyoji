﻿Imports Nukepayload2.Linq.Onmyoji.御魂种类
Imports Nukepayload2.Linq.Onmyoji.御魂属性类型
Imports Nukepayload2.Linq.Onmyoji.副属性条数

Partial Class 御魂整理宏示例

    ''' <summary>
    ''' http://www.bilibili.com/video/av98225095
    ''' </summary>
    Public Sub 阿毛缘结神版本御魂整理方案()
        ' 全部六星弃置
        星级.改为(6)
        副属性条数 = 不限
        全选.弃置
        重置过滤器

        ' 接下来要做的是反向慢慢恢复,这样无论效率还是彻底程度都比正向要快很多。
        在弃置御魂中查找 = True

        ' 目前有用的是攻击加成,暴击,暴击伤害, 命中（土蜘蛛）,生命（地震鲶）。
        ' 但是由于首领御魂少, 不过滤。
        种类.改为(土蜘蛛, 胧车, 荒骷髅, 地震鲶, 蜃气楼, 鬼灵歌伎)
        全选.恢复
        重置过滤器

        ' 速度御魂
        ' 1, 3, 4, 5, 6 副属性 速度 恢复
        位置.选择(1, 3, 4, 5, 6)
        副属性有.改为(速度)
        全选.恢复
        重置过滤器
        ' 2 号主速度副速度三条以上恢复
        位置.改为(2)
        主属性.改为(速度)
        副属性条数 = 三条或更多
        全选.恢复
        重置过滤器

        ' 命中和抵抗
        主属性.改为(效果命中)
        副属性有.改为(效果命中)
        全选.恢复
        副属性有.改为(效果抵抗)
        全选.恢复
        主属性.改为(效果抵抗)
        副属性有.改为(效果命中)
        全选.恢复
        副属性有.改为(效果抵抗)
        全选.恢复
        重置过滤器

        ' 暴击和暴伤全恢复
        主属性.改为(暴击)
        全选.恢复
        主属性.改为(暴击伤害)
        全选.恢复
        重置过滤器

        ' 暴击类
        种类.改为(雪幽魂, 地藏像, 三味, 招财猫, 轮入道, 狰, 火灵, 薙魂,
                      心眼, 木魅, 树妖, 网切, 青女房, 伤魂鸟, 破势, 镇墓兽,
                      珍珠, 骰子鬼, 蚌精, 针女, 鸣屋, 狂骨, 兵主部, 涂佛)
        ' 135 三条或更多,副属性 暴击 或者 暴击伤害
        位置.改为(1, 3, 5)
        副属性条数 = 三条或更多
        副属性有.改为(暴击)
        全选.恢复
        副属性有.改为(暴击伤害)
        全选.恢复
        副属性条数 = 不限
        ' 2 号速度,副属性 暴击 或者 暴击伤害
        位置.改为(2)
        主属性.改为(速度)
        副属性有.改为(暴击)
        全选.恢复
        副属性有.改为(暴击伤害)
        全选.恢复
        ' 去掉树妖和珍珠,246 主攻击加成,副属性 暴击 或者 暴击伤害
        种类.去掉(树妖, 珍珠)
        位置.改为(2, 4, 6)
        主属性.改为(攻击加成)
        副属性有.改为(暴击)
        全选.恢复
        副属性有.改为(暴击伤害)
        全选.恢复
        ' 去掉雪幽魂,骰子鬼,轮入道,狰等等,246主生命加成副属性暴击暴击伤害
        种类.按属性去掉(防御加成, 攻击加成, 效果命中, 效果抵抗)
        位置.改为(2, 4, 6)
        主属性.改为(生命加成)
        副属性有.改为(暴击)
        全选.恢复
        副属性有.改为(暴击伤害)
        全选.恢复
        重置过滤器

        ' 生命类
        种类.改为(地藏像, 招财猫, 薙魂, 涅槃之火, 树妖, 被服, 钟灵, 镜姬, 涂佛)
        ' 135 三条或更多, 副属性生命加成
        位置.改为(1, 3, 5)
        副属性条数 = 三条或更多
        副属性有.改为(生命加成)
        全选.恢复
        副属性条数 = 不限
        ' 246 主属性副属性生命加成
        位置.改为(2, 4, 6)
        主属性.改为(生命加成)
        副属性有.改为(生命加成)
        全选.恢复
        重置过滤器

        ' 攻击类
        种类.改为(招财猫, 蝠翼, 心眼, 狰, 轮入道, 狂骨, 阴摩罗, 兵主部, 鸣屋)
        ' 135 三条或更多, 副属性攻击加成
        位置.改为(1, 3, 5)
        副属性条数 = 三条或更多
        副属性有.改为(攻击加成)
        全选.恢复
        副属性条数 = 不限
        ' 246 主属性副属性攻击加成
        位置.改为(2, 4, 6)
        主属性.改为(攻击加成)
        副属性有.改为(攻击加成)
        全选.恢复
        重置过滤器

        ' 效果命中类 1
        种类.改为(雪幽魂, 招财猫, 地藏像, 三味, 狂骨, 蚌精, 日女巳时, 魅妖,
                      鸣屋, 木魅, 反枕, 薙魂, 火灵, 钟灵, 返魂香, 魍魉之匣,
                      飞缘魔, 轮入道, 心眼, 破势)
        ' 135 三条或更多, 副属性效果命中
        位置.改为(1, 3, 5)
        副属性条数 = 三条或更多
        副属性有.改为(效果命中)
        全选.恢复
        副属性条数 = 不限
        ' 2 号位主属性速度副属性命中
        位置.改为(2)
        主属性.改为(速度)
        全选.恢复
        ' 6 号位副属性命中
        位置.改为(6)
        主属性.重置()
        全选.恢复
        重置过滤器

        ' 效果命中类 2
        种类.改为(雪幽魂, 招财猫, 蚌精, 魅妖, 火灵, 幽谷响, 钟灵, 魍魉之匣,
                      木魅, 反枕, 鸣屋, 返魂香)
        ' 二号位主属性攻击加成,副属性效果命中
        位置.改为(2)
        主属性.改为(攻击加成)
        副属性有.改为(效果命中)
        全选.恢复
        ' 去掉鸣屋,主属性生命加成,副属性效果命中恢复
        种类.去掉(鸣屋)
        位置.重置()
        主属性.改为(生命加成)
        全选.恢复
        重置过滤器

        ' 效果抵抗类 1
        种类.改为(招财猫, 地藏像, 三味, 蚌精, 魅妖, 镜姬, 火灵, 幽谷响,
                      薙魂, 木魅, 返魂香, 骰子鬼, 轮入道, 魍魉之匣)
        ' 135 三条或更多, 副属性效果抵抗
        位置.改为(1, 3, 5)
        副属性条数 = 三条或更多
        副属性有.改为(效果抵抗)
        全选.恢复
        副属性条数 = 不限
        ' 2 号位主属性速度副属性抵抗
        位置.改为(2)
        主属性.改为(速度)
        全选.恢复
        ' 6 号位副属性抵抗
        位置.改为(6)
        主属性.重置()
        全选.恢复
        重置过滤器

        ' 效果抵抗类 2
        种类.改为(蚌精, 木魅, 招财猫, 返魂香, 骰子鬼, 火灵, 魍魉之匣, 魅妖, 薙魂)
        ' 二号位主属性攻击加成,副属性效果抵抗
        位置.改为(2)
        主属性.改为(攻击加成)
        副属性有.改为(效果抵抗)
        全选.恢复
        ' 去掉骰子鬼,主属性生命加成,副属性效果抵抗恢复
        种类.去掉(骰子鬼)
        位置.重置()
        主属性.改为(生命加成)
        全选.恢复
        重置过滤器
    End Sub
End Class
