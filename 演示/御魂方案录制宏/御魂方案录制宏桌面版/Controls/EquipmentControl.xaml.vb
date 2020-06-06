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
        ctl.UpdateEquipment(御魂)
    End Sub

    Private Sub UpdateEquipment(御魂 As 御魂)
        If 御魂 IsNot Nothing Then
            Dim 种类中文名 = 御魂.种类中文名
            TxtInfo.EquipmentType = 御魂.种类
            TxtInfo.Direction = 御魂.位置从1开始
            UpdateTooltip(御魂)
            ArrJades.JadeCount = 御魂.星级
            RunLevel.Text = 御魂.等级
            If 御魂.已锁定 Then
                TblLock.Visibility = Visibility.Visible
            End If
        Else
            TxtInfo.EquipmentType = 御魂种类.雪幽魂
            TxtInfo.Direction = 7 ' 坏掉的位置
        End If
    End Sub

    Private Sub UpdateTooltip(御魂 As 御魂)
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
        Dim propGrowths As IEnumerable = Nothing
        If 御魂.随机属性比率 IsNot Nothing Then
            propGrowths = From sec In 御魂.随机属性比率
                          Let type = sec.属性分类
                          Select New With {
                              .Name = type.ToString,
                              .Value = sec.数值,
                              .Format = sec.数字格式
                          }
        End If
        With TipMoreInfo
            .Jade = 御魂.星级
            .EquipmentType = 御魂.种类
            .Level = 御魂.等级
            .Properties = props
            .Direction = 御魂.位置从1开始
            .IsLocked = 御魂.已锁定
            .PropertyGrowths = propGrowths
            If 御魂.单个属性.Length > 0 Then
                .SingleProperty = 御魂.单个属性(0)
            End If
        End With
    End Sub

End Class
