Public Class 御魂图鉴条目
    Public Sub New(id As Integer, 属性 As (String, Double), 效果 As String, 是首领御魂 As Boolean)
        Me.Id = id
        With 属性
            属性类型 = .Item1
            属性数值 = .Item2
        End With
        Me.效果 = 效果
        Me.是首领御魂 = 是首领御魂
    End Sub

    ''' <summary>
    ''' 游戏内部使用的 id, 可能的值在 <see cref="御魂种类"/> 里。
    ''' </summary>
    Public Property Id As Integer
    ''' <summary>
    ''' 御魂套装属性的英文名
    ''' </summary>
    Public Property 属性类型 As String
    ''' <summary>
    ''' 御魂套装属性的数值，例如 0.15 代表 15% 。
    ''' </summary>
    Public Property 属性数值 As Double
    ''' <summary>
    ''' 御魂套装效果
    ''' </summary>
    Public Property 效果 As String
    ''' <summary>
    ''' 表示此御魂是否是首领御魂
    ''' </summary>
    Public Property 是首领御魂 As Boolean
End Class
