Imports Nukepayload2.Linq.Onmyoji

Public Class EquipmentPresenter

    Public Property EquipmentType As 御魂种类
        Get
            Return GetValue(EquipmentTypeProperty)
        End Get
        Set
            SetValue(EquipmentTypeProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly EquipmentTypeProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(EquipmentType),
                           GetType(御魂种类), GetType(EquipmentPresenter),
                           New PropertyMetadata(御魂种类.破势))

End Class
