Public Class UniformWrapGrid
	Inherits WrapPanel

	Protected Overrides Function MeasureOverride(availableSize As Size) As Size
		If Children.Count > 0 Then
			If Orientation = Orientation.Horizontal Then
				Dim totalWidth As Double = availableSize.Width
				ItemWidth = 0.0
				For Each el In Children.OfType(Of UIElement)
					el.Measure(availableSize)
					Dim [next] As Size = el.DesiredSize
					If Not (Double.IsInfinity([next].Width) OrElse Double.IsNaN([next].Width)) Then
						ItemWidth = Math.Max([next].Width, ItemWidth)
					End If
				Next el
			Else
				Dim totalHeight As Double = availableSize.Height
				ItemHeight = 0.0
				For Each el In Children.OfType(Of UIElement)
					el.Measure(availableSize)
					Dim [next] As Size = el.DesiredSize
					If Not (Double.IsInfinity([next].Height) OrElse Double.IsNaN([next].Height)) Then
						ItemHeight = Math.Max([next].Height, ItemHeight)
					End If
				Next el
			End If
		End If
		Return MyBase.MeasureOverride(availableSize)
	End Function

End Class
