Public Class FilterIncludePropertyWithVisibility
    Inherits FilterIncludeProperty

    Dim _IsVisible As Boolean = True
    Public Property IsVisible As Boolean
        Get
            Return _IsVisible
        End Get
        Set(value As Boolean)
            If _IsVisible <> value Then
                _IsVisible = value
                RaisePropertyChanged()
            End If
        End Set
    End Property

    Sub New()

    End Sub

    Public Sub New(name As String)
        MyBase.New(name)
    End Sub

End Class
