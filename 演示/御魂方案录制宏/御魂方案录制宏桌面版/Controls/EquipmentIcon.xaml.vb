Imports Nukepayload2.Linq.Onmyoji

Public Class EquipmentIcon

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
                           GetType(御魂种类), GetType(EquipmentIcon),
                           New PropertyMetadata(御魂种类.雪幽魂, AddressOf OnTypeChanged))

    Private Shared Sub OnTypeChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentIcon = d
        Dim newValue As 御魂种类 = e.NewValue
        inst.ImgEquipment.ImageSource = My.Images.FromEquipmentId(newValue)
    End Sub

    Public Property Direction As Integer
        Get
            Return GetValue(DirectionProperty)
        End Get
        Set
            SetValue(DirectionProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly DirectionProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Direction),
                           GetType(Integer), GetType(EquipmentIcon),
                           New PropertyMetadata(1, AddressOf OnDirectionChanged))

    Private Shared Sub OnDirectionChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentIcon = d
        Dim direction As Integer = e.NewValue
        If direction < 1 OrElse direction > 8 Then
            direction = 1
        End If
        Dim rotation = s_rotations(direction - 1)
        inst.RotFrame.Angle = rotation
    End Sub

    Private Shared ReadOnly s_rotations As Double() = {0, -45, -90, -180, -225, -270, 45, -135}
End Class
