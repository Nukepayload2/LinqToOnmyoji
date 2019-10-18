Public Class 御魂

    <JsonPropertyName("attrs")>
    Public Property 副属性 As 御魂副属性()

    <JsonPropertyName("base_attr")>
    Public Property 主属性 As 御魂主属性

    <JsonPropertyName("born")>
    Public Property 已召唤 As Integer

    <JsonPropertyName("equip_id")>
    Public Property 装备Id As Integer

    <JsonPropertyName("garbage")>
    Public Property 已弃置 As Boolean

    <JsonPropertyName("id")>
    Public Property Id As String

    <JsonPropertyName("level")>
    Public Property 等级 As Integer

    <JsonPropertyName("lock")>
    Public Property 已锁定 As Boolean

    ''' <summary>
    ''' 0 到 5。代表 1 到 6 号位。
    ''' </summary>
    <JsonPropertyName("pos")>
    Public Property 位置从0开始 As Integer

    ''' <summary>
    ''' 1 到 6。代表 1 到 6 星。
    ''' </summary>
    <JsonPropertyName("quality")>
    Public Property 星级 As Integer

    <JsonPropertyName("random_attr_rates")>
    Public Property 随机属性比率 As 御魂随机属性强化比率()

    <JsonPropertyName("random_attrs")>
    Public Property 随机属性 As 御魂随机属性()

    <JsonPropertyName("single_attrs")>
    Public Property 单个属性 As 御魂单个属性()

    <JsonPropertyName("suit_id")>
    Public Property 套装类型Id As Integer
End Class
