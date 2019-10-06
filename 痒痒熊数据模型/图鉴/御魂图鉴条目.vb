Public Class 御魂图鉴条目
    Public Sub New(id As Integer, 属性 As (String, Double), 效果 As String, 是首领御魂 As Boolean)
        Me.Id = id
        Me.属性 = 属性
        Me.效果 = 效果
        Me.是首领御魂 = 是首领御魂
    End Sub

    Public Property Id As Integer
    Public Property 属性 As (类型 As String, 数值 As Double)
    Public Property 效果 As String
    Public Property 是首领御魂 As Boolean
End Class
