Imports System.ComponentModel

Public Class FilterIncludeExcludeProperty
    Implements INotifyPropertyChanged

    Dim _Name As String
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            If _Name <> value Then
                _Name = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Name)))
            End If
        End Set
    End Property

    Dim _IncludeProperty As Boolean
    Public Property IncludeProperty As Boolean
        Get
            Return _IncludeProperty
        End Get
        Set(value As Boolean)
            If _IncludeProperty <> value Then
                _IncludeProperty = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(IncludeProperty)))
            End If
        End Set
    End Property

    Dim _ExcludeProperty As Boolean
    Public Property ExcludeProperty As Boolean
        Get
            Return _ExcludeProperty
        End Get
        Set(value As Boolean)
            If _ExcludeProperty <> value Then
                _ExcludeProperty = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ExcludeProperty)))
            End If
        End Set
    End Property

    Sub New()

    End Sub

    Public Sub New(name As String)
        _Name = name
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
