Public Class JadeControlArray

    Private Shared ReadOnly s_jade As String = "9"
    Private Shared ReadOnly s_1Jade As IEnumerable = {s_jade}
    Private Shared ReadOnly s_2Jades As IEnumerable = {s_jade, s_jade}
    Private Shared ReadOnly s_3Jades As IEnumerable = {s_jade, s_jade, s_jade}
    Private Shared ReadOnly s_4Jades As IEnumerable = {s_jade, s_jade, s_jade, s_jade}
    Private Shared ReadOnly s_5Jades As IEnumerable = {s_jade, s_jade, s_jade, s_jade, s_jade}
    Private Shared ReadOnly s_6Jades As IEnumerable = {s_jade, s_jade, s_jade, s_jade, s_jade, s_jade}

    Private Shared ReadOnly s_jades() As IEnumerable = {
        s_1Jade, s_2Jades, s_3Jades, s_4Jades, s_5Jades, s_6Jades
    }

    Public Property JadeCount As Integer
        Get
            Return GetValue(JadeCountProperty)
        End Get
        Set
            SetValue(JadeCountProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly JadeCountProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(JadeCount),
                           GetType(Integer), GetType(JadeControlArray),
                           New PropertyMetadata(0, AddressOf OnJadeCountChanged))

    Private Shared Sub OnJadeCountChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As JadeControlArray = d
        Dim newVal As Integer = e.NewValue
        newVal = Math.Max(1, newVal)
        newVal = Math.Min(6, newVal)
        inst.ItmJades.ItemsSource = s_jades(newVal - 1)
    End Sub
End Class
