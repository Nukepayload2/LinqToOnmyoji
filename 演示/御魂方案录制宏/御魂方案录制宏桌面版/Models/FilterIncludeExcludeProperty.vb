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

    Dim _HasProperty As Boolean
    Public Property HasProperty As Boolean
        Get
            Return _HasProperty
        End Get
        Set(value As Boolean)
            If _HasProperty <> value Then
                _HasProperty = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(HasProperty)))
            End If
        End Set
    End Property

    Dim _DoesNotHasProperty As Boolean
    Public Property DoesNotHasProperty As Boolean
        Get
            Return _DoesNotHasProperty
        End Get
        Set(value As Boolean)
            If _DoesNotHasProperty <> value Then
                _DoesNotHasProperty = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(DoesNotHasProperty)))
            End If
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
