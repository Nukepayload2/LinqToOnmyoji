Imports Nukepayload2.Linq.Onmyoji

Public Class ShowAboutCommand
    Inherits Singleton(Of ShowAboutCommand)
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        MsgBox($"版本 1.1 preview 1, 适配{痒痒熊快照.已适配的产品和版本}。
作者: 
B站、GitHub、百度贴吧、微博：Nukepayload2。
阴阳师：依偎相守#2723416
攻略：
B站 解说七老爷", vbInformation, "关于")
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
