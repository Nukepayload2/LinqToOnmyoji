Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class FilterIncludeProperty
    Implements INotifyPropertyChanged

    Dim _Name As String
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            If _Name <> value Then
                _Name = value
                RaisePropertyChanged()
            End If
        End Set
    End Property

    Dim _IsSelected As Boolean

    Public Property IsSelected As Boolean
        Get
            Return _IsSelected
        End Get
        Set(value As Boolean)
            If _IsSelected <> value Then
                _IsSelected = value
                RaisePropertyChanged()
            End If
        End Set
    End Property

    Protected Sub RaisePropertyChanged(<CallerMemberName> Optional name As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Sub New()

    End Sub

    Public Sub New(name As String)
        _Name = name
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
