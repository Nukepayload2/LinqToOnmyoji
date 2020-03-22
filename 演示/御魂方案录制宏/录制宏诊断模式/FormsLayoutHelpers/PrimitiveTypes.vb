Friend Enum Visibility
    Visible
    Collapsed
End Enum

Friend Enum VerticalAlignment
    Stretch
    Top
    Center
    Bottom
End Enum

Friend Enum HorizontalAlignment
    Stretch
    Left
    Center
    Right
End Enum

Friend Enum Orientation
    Vertical
    Horizontal
End Enum

Friend Structure Thickness
    Public Sub New(left As Single, top As Single, right As Single, bottom As Single)
        Me.Left = left
        Me.Top = top
        Me.Right = right
        Me.Bottom = bottom
    End Sub

    Public Left As Single
    Public Top As Single
    Public Right As Single
    Public Bottom As Single
End Structure
