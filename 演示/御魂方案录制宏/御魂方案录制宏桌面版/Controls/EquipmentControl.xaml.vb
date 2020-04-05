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
        Dim 御魂 As 御魂 = e.NewValue
        If 御魂 IsNot Nothing Then
            Dim 种类中文名 = 御魂.种类中文名
            ctl.TxtInfo.EquipmentType = 御魂.种类
            ctl.TxtInfo.Direction = 御魂.位置从1开始
            Dim 主属性 = 御魂.主属性
            Dim primary = New With {
                .Name = 主属性.属性分类.ToString,
                .Value = 主属性.数值,
                .Format = 主属性.属性分类.数字格式
            }
            Dim secondaries = From sec In 御魂.副属性
                              Let type = sec.属性分类
                              Select New With {
                                  .Name = type.ToString,
                                  .Value = sec.数值,
                                  .Format = type.数字格式
                              }
            Dim props = Enumerable.Repeat(primary, 1).Concat(secondaries)
            With ctl.TipMoreInfo
                .Jade = 御魂.星级
                .EquipmentType = 御魂.种类
                .Level = 御魂.等级
                .Properties = props
                .Direction = 御魂.位置从1开始
            End With
            ctl.ArrJades.JadeCount = 御魂.星级
            ctl.RunLevel.Text = 御魂.等级
        Else
            ctl.TxtInfo.EquipmentType = 御魂种类.雪幽魂
            ctl.TxtInfo.Direction = 7 ' 坏掉的位置
        End If
    End Sub

End Class
