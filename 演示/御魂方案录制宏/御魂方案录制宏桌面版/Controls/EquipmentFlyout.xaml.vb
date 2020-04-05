Imports Nukepayload2.Linq.Onmyoji

Public Class EquipmentFlyout

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
                           GetType(御魂种类), GetType(EquipmentFlyout),
                           New PropertyMetadata(御魂种类.雪幽魂, AddressOf OnEquipmentTypeChanged))

    ''' <summary>
    ''' 强化等级 (0~15)
    ''' </summary>
    Public Property Level As Integer
        Get
            Return GetValue(LevelProperty)
        End Get
        Set
            SetValue(LevelProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly LevelProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Level),
                           GetType(Integer), GetType(EquipmentFlyout),
                           New PropertyMetadata(1, AddressOf OnLevelChanged))

    Public Property Jade As Integer
        Get
            Return GetValue(JadeProperty)
        End Get
        Set
            SetValue(JadeProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly JadeProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Jade),
                           GetType(Integer), GetType(EquipmentFlyout),
                           New PropertyMetadata(6, AddressOf OnJadeChanged))

    ''' <summary>
    ''' 主属性和副属性。数据类型：Name As String, Value As Double, Format As String
    ''' </summary>
    Public Property Properties As IEnumerable
        Get
            Return GetValue(PropertiesProperty)
        End Get
        Set
            SetValue(PropertiesProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly PropertiesProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Properties),
                           GetType(IEnumerable), GetType(EquipmentFlyout),
                           New PropertyMetadata(Array.Empty(Of Object), AddressOf OnPropertiesChanged))

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
                           GetType(Integer), GetType(EquipmentFlyout),
                           New PropertyMetadata(1, AddressOf OnDirectionChanged))

    Public Property IsLocked As Boolean
        Get
            Return GetValue(IsLockedProperty)
        End Get
        Set
            SetValue(IsLockedProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly IsLockedProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(IsLocked),
                           GetType(Boolean), GetType(EquipmentFlyout),
                           New PropertyMetadata(False, AddressOf OnLockedChanged))

    Private Shared Sub OnLockedChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        inst.ChkLocked.IsChecked = e.NewValue
    End Sub

    Private Shared Sub OnEquipmentTypeChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        Dim type As 御魂种类 = e.NewValue
        inst.RunType.Text = type.ToString
        inst.IcoEquipmentType.EquipmentType = type
    End Sub

    Private Shared Sub OnLevelChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        inst.RunLevel.Text = e.NewValue
    End Sub

    Private Shared Sub OnJadeChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        inst.ItmJades.JadeCount = e.NewValue
    End Sub

    Private Shared Sub OnPropertiesChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        inst.ItmProps.ItemsSource = e.NewValue
    End Sub

    Private Shared Sub OnDirectionChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        inst.IcoEquipmentType.Direction = e.NewValue
    End Sub

End Class
