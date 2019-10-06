# LinqToOnmyoji
提供一组 .NET Standard 2.0 的 API，使用语言集成查询分析痒痒熊导出器导出的数据。

## 功能
- 导入痒痒熊快照产生的 json 文件
- 使用强类型的 API 查询快照 json 文件的原始内容
- 对于过于原始的内容，如御魂种类编号，提供对应的枚举类型
- 提供一组对于中国人而言易用、一定程度上容错的 API 进行御魂整理

## 先决条件
- 对阴阳师的游戏机制有足够的了解，能够编写攻略或者能看懂几乎所有攻略
- 熟悉 .NET 程序开发，C# 和 VB 至少要会一种
- 掌握语言集成查询

## 快速入门
查询的入口是痒痒熊快照。加载快照之后对快照中的数据进行查询。
下面的代码统计每种御魂的数量。其中用到的 `测试数据.json` 文件在本仓库的测试程序文件夹中。

__VB__
```vbnet
Dim 快照 = 痒痒熊快照.加载Json文件("测试数据.json")
Dim eqId = Aggregate 御魂 In 快照.数据.御魂
           Group By 御魂.名称 Into Group
           Select 名称, Group.Count Into ToArray

For Each eq In eqId
    Console.WriteLine(eq)
Next
```
代码产生形如如下的输出
```console
{ 名称 = 阴摩罗, Count = 131 }
{ 名称 = 心眼, Count = 182 }
{ 名称 = 破势, Count = 266 }
{ 名称 = 雪幽魂, Count = 123 }
...
```