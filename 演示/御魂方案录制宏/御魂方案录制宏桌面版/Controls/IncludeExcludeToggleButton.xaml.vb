Public Class IncludeExcludeToggleButton

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
                           GetType(Object), GetType(IncludeExcludeToggleButton),
                           New PropertyMetadata(Nothing, AddressOf Header_Changed))

    Private Shared Sub Header_Changed(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        If e.NewValue = e.OldValue Then Return
        Dim instance As IncludeExcludeToggleButton = d
        instance.CtlHeader.Content = e.NewValue
    End Sub

    Public Property IsIncludeChecked As Boolean
        Get
            Return GetValue(IsIncludeCheckedProperty)
        End Get
        Set
            SetValue(IsIncludeCheckedProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly IsIncludeCheckedProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(IsIncludeChecked),
                           GetType(Boolean), GetType(IncludeExcludeToggleButton),
                           New PropertyMetadata(False, AddressOf IsIncludeChecked_Changed))

    Private Shared Sub IsIncludeChecked_Changed(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        If e.NewValue = e.OldValue Then Return
        Dim instance As IncludeExcludeToggleButton = d
        Dim newValue As Boolean = e.NewValue
        instance.BtnInclude.IsChecked = newValue
    End Sub

    Public Property IsExcludeChecked As Boolean
        Get
            Return GetValue(IsExcludeCheckedProperty)
        End Get
        Set
            SetValue(IsExcludeCheckedProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly IsExcludeCheckedProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(IsExcludeChecked),
                           GetType(Boolean), GetType(IncludeExcludeToggleButton),
                           New PropertyMetadata(False, AddressOf IsExcludeChecked_Changed))

    Private Shared Sub IsExcludeChecked_Changed(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        If e.NewValue = e.OldValue Then Return
        Dim instance As IncludeExcludeToggleButton = d
        Dim newValue As Boolean = e.NewValue
        instance.BtnExclude.IsChecked = newValue
    End Sub

    Private Sub BtnExclude_Checked(sender As Object, e As RoutedEventArgs) Handles BtnExclude.Checked
        IsExcludeChecked = True
        IsIncludeChecked = False
    End Sub

    Private Sub BtnExclude_Unchecked(sender As Object, e As RoutedEventArgs) Handles BtnExclude.Unchecked
        IsExcludeChecked = False
    End Sub

    Private Sub BtnInclude_Checked(sender As Object, e As RoutedEventArgs) Handles BtnInclude.Checked
        IsIncludeChecked = True
        IsExcludeChecked = False
    End Sub

    Private Sub BtnInclude_Unchecked(sender As Object, e As RoutedEventArgs) Handles BtnInclude.Unchecked
        IsIncludeChecked = False
    End Sub
End Class
