Public Class FlyoutService
    Private Shared ReadOnly s_hostList As New Stack(Of PanelFlyout)

    Public Shared Sub AddFlyoutHost(host As Panel)
        If host Is Nothing Then
            Throw New ArgumentNullException(NameOf(host))
        End If

        s_hostList.Push(New PanelFlyout(host, Nothing))
    End Sub

    Public Shared Sub RemoveFlyoutHost()
        Dim removed = s_hostList.Pop()
        Dim flyout = TryCast(removed.flyout, IFlyout)
        flyout?.ForceClose()
    End Sub

    Public Shared ReadOnly Property HasFlyoutHost As Boolean
        Get
            Return s_hostList.Count > 0
        End Get
    End Property

    Public Shared Sub Show(flyout As FrameworkElement)
        AssertHasFlyoutHost()
        Dim host = s_hostList.Peek
        If host.flyout IsNot Nothing Then
            Throw New InvalidOperationException("内部错误：尝试同时显示多个 Flyout")
        End If
        host.panel.Children.Add(flyout)
        host.panel.Visibility = Visibility.Visible
        host.flyout = flyout
    End Sub

    Public Shared Sub Dismiss(flyout As FrameworkElement)
        AssertHasFlyoutHost()
        Dim host = s_hostList.Peek
        If host.flyout Is Nothing Then
            Throw New InvalidOperationException("内部错误：尝试关闭未显示的 Flyout")
        End If
        host.flyout = Nothing
        host.panel.Children.Remove(flyout)
        host.panel.Visibility = Visibility.Collapsed
    End Sub

    Private Shared Sub AssertHasFlyoutHost()
        If Not HasFlyoutHost Then
            Throw New InvalidOperationException("内部错误：未设置活动的 Flyout host")
        End If
    End Sub

    Private Class PanelFlyout
        Public Sub New(panel As Panel, flyout As FrameworkElement)
            Me.Panel = panel
            Me.Flyout = flyout
        End Sub

        Public Property Panel As Panel
        Public Property Flyout As FrameworkElement
    End Class
End Class
