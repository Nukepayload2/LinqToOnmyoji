''' <summary>
''' 描述录制时操作的影响
''' </summary>
Public MustInherit Class 宏录制操作行为
    Protected Sub New(过程 As 宏过程)
        Me.过程 = 过程
    End Sub

    Public ReadOnly Property 过程 As 宏过程

    Public MustOverride Sub 执行()
    Public MustOverride Sub 撤销()
End Class
