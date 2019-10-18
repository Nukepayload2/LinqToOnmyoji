Public Class 式神录

    <JsonProperty("book_max_shards"), JsonPropertyName("book_max_shards")>
    Public Property 契约书合成所需碎片数量 As Integer

    <JsonProperty("books"), JsonPropertyName("books")>
    Public Property 契约书 As Integer

    <JsonProperty("hero_id"), JsonPropertyName("hero_id")>
    Public Property 式神Id As Integer

    <JsonProperty("shards"), JsonPropertyName("shards")>
    Public Property 碎片数量 As Integer
End Class
