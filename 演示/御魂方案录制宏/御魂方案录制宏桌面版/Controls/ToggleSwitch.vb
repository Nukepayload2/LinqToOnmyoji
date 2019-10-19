Imports System.Windows.Controls.Primitives

Public Class ToggleSwitch
    Inherits ToggleButton

    Shared Sub New()
        DefaultStyleKeyProperty.OverrideMetadata(GetType(ToggleSwitch),
                                                 New FrameworkPropertyMetadata(GetType(ToggleSwitch)))
    End Sub

End Class
