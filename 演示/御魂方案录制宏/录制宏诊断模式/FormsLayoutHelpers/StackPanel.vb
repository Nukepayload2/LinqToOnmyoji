Friend Class StackPanel
    Inherits PanelBase

    Public Property Orientation As Orientation

    Protected Overrides Function MeasureOverride(availableSize As SizeF) As SizeF
        Dim widthCalc = 0.0F
        Dim heightCalc = 0.0F

        Dim isHorizontal As Boolean = Orientation = Orientation.Horizontal
        For Each child In Children
            child.Measure(availableSize)
            Dim childSize = child.DesiredSize
            If isHorizontal Then
                widthCalc += childSize.Width
                heightCalc = Math.Max(heightCalc, childSize.Height)
            Else
                widthCalc = Math.Max(widthCalc, childSize.Width)
                heightCalc += childSize.Height
            End If
        Next child
        Return New SizeF(widthCalc, heightCalc)
    End Function

    Protected Overrides Function ArrangeOverride(finalSize As SizeF) As SizeF
        Dim group As New UserControl
        Dim finalWidth = finalSize.Width
        Dim finalHeight = finalSize.Height

        Dim renderWidth = finalWidth
        Dim renderHeight = finalHeight

        AddBackgroundElementVisual(group)

        Dim leftOffset = 0.0F
        Dim topOffset = 0.0F
        Dim isHorizontal As Boolean = Orientation = Orientation.Horizontal

        For Each child In Children
            Dim childSize As SizeF = child.DesiredSize

            Dim left As Single = 0
            Dim top As Single = 0

            Dim childWidth As Single = childSize.Width
            Dim childHeight As Single = childSize.Height
            If isHorizontal Then
                top = GetAlignedTop(child.VerticalAlignment, finalHeight, childHeight)
                If child.VerticalAlignment = VerticalAlignment.Stretch Then
                    childHeight = renderHeight
                End If
            Else
                left = GetAlignedLeft(child.HorizontalAlignment, finalWidth, childWidth)
                If child.HorizontalAlignment = HorizontalAlignment.Stretch Then
                    childWidth = renderWidth
                End If
            End If
            Dim childBounds = New RectangleF(
                left + leftOffset, top + topOffset, childWidth, childHeight)

            If isHorizontal Then
                leftOffset += childWidth
            Else
                topOffset += childHeight
            End If
            child.Arrange(childBounds)
            Dim childElementVisual = child.ElementVisual
            group.Controls.Add(childElementVisual)
        Next child

        ElementVisual = group
        Return New SizeF(renderWidth, renderHeight)
    End Function
End Class
