Public Class EquipmentFlyout

    ''' <summary>
    ''' 御魂类型名称
    ''' </summary>
    Public Property TypeName As String
        Get
            Return GetValue(TypeNameProperty)
        End Get
        Set
            SetValue(TypeNameProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly TypeNameProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(TypeName),
                           GetType(String), GetType(EquipmentFlyout),
                           New PropertyMetadata(String.Empty, AddressOf OnTypeNameChanged))

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
                           New PropertyMetadata(1, AddressOf OnJadeChanged))

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

    Private Shared Sub OnTypeNameChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        inst.RunType.Text = e.NewValue
    End Sub

    Private Shared Sub OnLevelChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        inst.RunLevel.Text = e.NewValue
    End Sub

    Private Shared Sub OnJadeChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        Dim newVal As Integer = e.NewValue
        newVal = Math.Max(1, newVal)
        newVal = Math.Min(6, newVal)
        inst.ItmJades.ItemsSource = s_jades(newVal - 1)
    End Sub

    Private Shared Sub OnPropertiesChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As EquipmentFlyout = d
        inst.ItmProps.ItemsSource = e.NewValue
    End Sub

    Private Shared Sub OnDirectionChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        ' 影响贴图
    End Sub

    Private Shared ReadOnly s_jade As String = "J"
    Private Shared ReadOnly s_1Jade As IEnumerable = {s_jade}
    Private Shared ReadOnly s_2Jades As IEnumerable = {s_jade, s_jade}
    Private Shared ReadOnly s_3Jades As IEnumerable = {s_jade, s_jade, s_jade}
    Private Shared ReadOnly s_4Jades As IEnumerable = {s_jade, s_jade, s_jade, s_jade}
    Private Shared ReadOnly s_5Jades As IEnumerable = {s_jade, s_jade, s_jade, s_jade, s_jade}
    Private Shared ReadOnly s_6Jades As IEnumerable = {s_jade, s_jade, s_jade, s_jade, s_jade, s_jade}

    Private Shared ReadOnly s_jades() As IEnumerable = {
        s_1Jade, s_2Jades, s_3Jades, s_4Jades, s_5Jades, s_6Jades
    }

End Class
