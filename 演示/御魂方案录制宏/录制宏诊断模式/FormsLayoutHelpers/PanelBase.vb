Friend Class PanelBase
    Inherits UIElement

    Public ReadOnly Property Children As New List(Of UIElement)

    Public Property Background As Color?

    Protected Overrides Function MeasureOverride(availableSize As SizeF) As SizeF
        Dim widthCalc = 0.0F
        Dim heightCalc = 0.0F
        For Each child In Children
            child.Measure(availableSize)
            Dim childSize = child.DesiredSize
            widthCalc = Math.Max(widthCalc, childSize.Width)
            heightCalc = Math.Max(heightCalc, childSize.Height)
        Next child
        Return New SizeF(widthCalc, heightCalc)
    End Function

    Protected Overrides Function ArrangeOverride(finalSize As SizeF) As SizeF
        Dim group As New UserControl
        Dim renderWidth = finalSize.Width
        Dim renderHeight = finalSize.Height

        AddBackgroundElementVisual(group)

        For Each child In Children
            Dim childSize As SizeF = child.DesiredSize

            Dim left As Single = GetAlignedLeft(child.HorizontalAlignment,
                                                renderWidth, childSize.Width)
            Dim top As Single = GetAlignedTop(child.VerticalAlignment,
                                              renderHeight, childSize.Height)

            Dim childWidth = If(child.HorizontalAlignment = HorizontalAlignment.Stretch,
                renderWidth, childSize.Width)
            Dim childHeight = If(child.VerticalAlignment = VerticalAlignment.Stretch,
                renderHeight, childSize.Height)
            Dim childBounds = New RectangleF(left, top, childWidth, childHeight)
            child.Arrange(childBounds)
            Dim childElementVisual = child.ElementVisual
            group.Controls.Add(childElementVisual)
        Next child

        ElementVisual = group
        Return New SizeF(renderWidth, renderHeight)
    End Function

    Protected Sub AddBackgroundElementVisual(group As UserControl)
        If Background IsNot Nothing Then
            group.BackColor = Background.Value
        End If
    End Sub

    Protected Function GetAlignedTop(alignment As VerticalAlignment,
                                     parentHeight As Single,
                                     actualHeight As Single) As Single
        Select Case alignment
            Case VerticalAlignment.Top
                Return 0
            Case VerticalAlignment.Center
                Return (parentHeight - actualHeight) / 2
            Case VerticalAlignment.Bottom
                Return parentHeight - actualHeight
            Case VerticalAlignment.Stretch
                Return 0
            Case Else
                Return 0
        End Select
    End Function

    Protected Function GetAlignedLeft(alignment As HorizontalAlignment,
                                      parentWidth As Single,
                                      actualWidth As Single) As Single
        Select Case alignment
            Case HorizontalAlignment.Stretch
                Return 0
            Case HorizontalAlignment.Left
                Return 0
            Case HorizontalAlignment.Center
                Return (parentWidth - actualWidth) / 2
            Case HorizontalAlignment.Right
                Return parentWidth - actualWidth
            Case Else
                Return 0
        End Select
    End Function
End Class