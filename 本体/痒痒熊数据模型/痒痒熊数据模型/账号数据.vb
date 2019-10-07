Public Class 账号数据

    <JsonProperty("currency")>
    Public Property 资产 As 资产

    <JsonProperty("hero_book_shards")>
    Public Property 式神录 As 式神录()

    <JsonProperty("hero_equip_presets")>
    Public Property 御魂预设 As 御魂预设()

    <JsonProperty("hero_equips")>
    Public Property 御魂 As 御魂()

    <JsonProperty("heroes")>
    Public Property 式神 As 式神()

    <JsonProperty("player")>
    Public Property 玩家 As 玩家

    <JsonProperty("realm_cards")>
    Public Property 结界卡 As 结界卡()

    <JsonProperty("story_tasks")>
    Public Property 主线任务 As 主线任务()
End Class
