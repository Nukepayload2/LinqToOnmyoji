Public Class FormattedTextBlock

    Public Property Value As Object
        Get
            Return GetValue(ValueProperty)
        End Get
        Set
            SetValue(ValueProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly ValueProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Value),
                           GetType(Object), GetType(FormattedTextBlock),
                           New PropertyMetadata(Nothing, AddressOf RefreshText))

    Public Property Format As String
        Get
            Return GetValue(FormatProperty)
        End Get
        Set
            SetValue(FormatProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly FormatProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Format),
                           GetType(String), GetType(FormattedTextBlock),
                           New PropertyMetadata(String.Empty, AddressOf RefreshText))

    Private Shared Sub RefreshText(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As FormattedTextBlock = d
        If inst.Format = Nothing Then
            inst.TblText.Text = inst.Value
        Else
            inst.TblText.Text = String.Format(inst.Format, inst.Value)
        End If
    End Sub

End Class
