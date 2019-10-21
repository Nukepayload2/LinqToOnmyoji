Public Class ThreeStatesToggleButton

    Public Property Header As Object
        Get
            Return GetValue(HeaderProperty)
        End Get
        Set
            SetValue(HeaderProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly HeaderProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Header),
                           GetType(Object), GetType(ThreeStatesToggleButton),
                           New PropertyMetadata(Nothing, AddressOf Header_Changed))

    Private Shared Sub Header_Changed(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim instance As ThreeStatesToggleButton = d
        instance.CtlHeader.Content = e.NewValue
    End Sub

    Public Property IsChecked As Boolean?
        Get
            Return GetValue(IsCheckedProperty)
        End Get
        Set
            SetValue(IsCheckedProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly IsCheckedProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(IsChecked),
                           GetType(Boolean?), GetType(ThreeStatesToggleButton),
                           New PropertyMetadata(Nothing, AddressOf IsChecked_Changed))

    Private Shared Sub IsChecked_Changed(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        If e.NewValue = e.OldValue Then Return
        Dim instance As ThreeStatesToggleButton = d
        Dim newValue As Boolean? = e.NewValue
        instance._isChangingButtonStateByIsChecked = True
        If newValue Is Nothing Then
            instance.BtnInclude.IsChecked = False
            instance.BtnExclude.IsChecked = False
        ElseIf newValue.Value Then
            instance.BtnInclude.IsChecked = True
            instance.BtnExclude.IsChecked = False
        Else
            instance.BtnInclude.IsChecked = False
            instance.BtnExclude.IsChecked = True
        End If
        instance._isChangingButtonStateByIsChecked = False
    End Sub

    Private _isChangingButtonStateByIsChecked As Boolean

    Private Sub BtnExclude_Checked(sender As Object, e As RoutedEventArgs) Handles BtnExclude.Checked
        If _isChangingButtonStateByIsChecked Then Return
        IsChecked = False
    End Sub

    Private Sub BtnExclude_Unchecked(sender As Object, e As RoutedEventArgs) Handles BtnExclude.Unchecked
        If _isChangingButtonStateByIsChecked Then Return
        IsChecked = Nothing
    End Sub

    Private Sub BtnInclude_Checked(sender As Object, e As RoutedEventArgs) Handles BtnInclude.Checked
        If _isChangingButtonStateByIsChecked Then Return
        IsChecked = True
    End Sub

    Private Sub BtnInclude_Unchecked(sender As Object, e As RoutedEventArgs) Handles BtnInclude.Unchecked
        If _isChangingButtonStateByIsChecked Then Return
        IsChecked = Nothing
    End Sub
End Class
