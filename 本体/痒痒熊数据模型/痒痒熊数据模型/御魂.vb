Public Class 御魂

    <JsonProperty("attrs")>
    Public Property 副属性 As 御魂副属性()

    <JsonProperty("base_attr")>
    Public Property 主属性 As 御魂主属性

    <JsonProperty("born")>
    Public Property 已召唤 As Integer

    <JsonProperty("equip_id")>
    Public Property 装备Id As Integer

    <JsonProperty("garbage")>
    Public Property 已弃置 As Boolean

    <JsonProperty("id")>
    Public Property Id As String

    <JsonProperty("level")>
    Public Property 等级 As Integer

    <JsonProperty("lock")>
    Public Property 已锁定 As Boolean

    ''' <summary>
    ''' 0 到 5。代表 1 到 6 号位。
    ''' </summary>
    <JsonProperty("pos")>
    Public Property 位置从0开始 As Integer

    ''' <summary>
    ''' 1 到 6。代表 1 到 6 星。
    ''' </summary>
    <JsonProperty("quality")>
    Public Property 星级 As Integer

    <JsonProperty("random_attr_rates")>
    Public Property 随机属性比率 As 御魂随机属性强化比率()

    <JsonProperty("random_attrs")>
    Public Property 随机属性 As 御魂随机属性()

    <JsonProperty("single_attrs")>
    Public Property 单个属性 As 御魂单个属性()

    <JsonProperty("suit_id")>
    Public Property 套装类型Id As Integer
End Class
