Imports System.ComponentModel

Public Class 文档信息
    Implements INotifyPropertyChanged

    Dim _名称 As String
    Public Property 名称 As String
        Get
            Return _名称
        End Get
        Set(value As String)
            If _名称 <> value Then
                _名称 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(名称)))
            End If
        End Set
    End Property

    Dim _版本 As String
    Public Property 版本 As String
        Get
            Return _版本
        End Get
        Set(value As String)
            If _版本 <> value Then
                _版本 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(版本)))
            End If
        End Set
    End Property

    Dim _说明 As String
    Public Property 说明 As String
        Get
            Return _说明
        End Get
        Set(value As String)
            If _说明 <> value Then
                _说明 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(说明)))
            End If
        End Set
    End Property

    Dim _发行说明 As String
    Public Property 发行说明 As String
        Get
            Return _发行说明
        End Get
        Set(value As String)
            If _发行说明 <> value Then
                _发行说明 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(发行说明)))
            End If
        End Set
    End Property

    Dim _作者 As String
    Public Property 作者 As String
        Get
            Return _作者
        End Get
        Set(value As String)
            If _作者 <> value Then
                _作者 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(作者)))
            End If
        End Set
    End Property

    Dim _版权 As String
    Public Property 版权 As String
        Get
            Return _版权
        End Get
        Set(value As String)
            If _版权 <> value Then
                _版权 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(版权)))
            End If
        End Set
    End Property

    Dim _许可协议名称 As String
    Public Property 许可协议名称 As String
        Get
            Return _许可协议名称
        End Get
        Set(value As String)
            If _许可协议名称 <> value Then
                _许可协议名称 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(许可协议名称)))
            End If
        End Set
    End Property

    Dim _自定义许可协议链接 As String
    Public Property 自定义许可协议链接 As String
        Get
            Return _自定义许可协议链接
        End Get
        Set(value As String)
            If _自定义许可协议链接 <> value Then
                _自定义许可协议链接 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(自定义许可协议链接)))
            End If
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
