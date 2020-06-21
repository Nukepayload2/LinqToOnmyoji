Imports Nukepayload2.Linq.Onmyoji

Public Class EquipmentMediumWideView

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
                           GetType(御魂种类), GetType(EquipmentMediumWideView),
                           New PropertyMetadata(御魂种类.雪幽魂, AddressOf OnTypeChanged))

    Private Shared Sub OnTypeChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentMediumWideView = d
        Dim newValue As 御魂种类 = e.NewValue
        inst.ImgEquipment.ImageSource = My.Images.FromEquipmentId(newValue)
        inst.TblEffectName.Text = 御魂图鉴.按类型查找(newValue).套装属性分类.ToString
    End Sub

    Public Property EquipmentCount As Integer
        Get
            Return GetValue(EquipmentCountProperty)
        End Get
        Set
            SetValue(EquipmentCountProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly EquipmentCountProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(EquipmentCount),
                           GetType(Integer), GetType(EquipmentMediumWideView),
                           New PropertyMetadata(0, AddressOf OnEquipmentCountChanged))

    Private Shared Sub OnEquipmentCountChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentMediumWideView = d
        inst.TblCount.Text = e.NewValue
    End Sub
End Class
