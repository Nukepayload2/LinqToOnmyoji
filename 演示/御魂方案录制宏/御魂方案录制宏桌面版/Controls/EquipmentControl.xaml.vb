Imports Nukepayload2.Linq.Onmyoji

Public Class EquipmentControl

    Public Property Equipment As 御魂
        Get
            Return GetValue(EquipmentProperty)
        End Get
        Set
            SetValue(EquipmentProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly EquipmentProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Equipment),
                           GetType(御魂), GetType(EquipmentControl),
                           New PropertyMetadata(Nothing, AddressOf EquipmentControl_EquipmentChanged))

    Private Shared Sub EquipmentControl_EquipmentChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim ctl As EquipmentControl = d
        Dim eq As 御魂 = e.NewValue
        If eq IsNot Nothing Then
            ctl.TxtInfo.Text = $"{eq.星级}星{eq.位置从1开始}号位{eq.种类中文名}"
        Else
            ctl.TxtInfo.Text = String.Empty
        End If
    End Sub
End Class
