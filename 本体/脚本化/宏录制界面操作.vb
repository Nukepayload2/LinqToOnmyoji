''' <summary>
''' 描述录制时操作的影响
''' </summary>
Public MustInherit Class 宏录制界面操作行为
    Public MustOverride Sub 执行()
    Public MustOverride Sub 撤销()
End Class
