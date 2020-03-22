Friend Class UIElement
    Public Property Name As String
    Public Property Visibility As Visibility
    Public Property Height As Single = Single.NaN
    Public Property Width As Single = Single.NaN
    Public Property MaxHeight As Single = Single.NaN
    Public Property MaxWidth As Single = Single.NaN

    Private _desiredSize As SizeF
    Public Property DesiredSize As SizeF
        Get
            Return _desiredSize
        End Get
        Protected Set(value As SizeF)
            _desiredSize = value
        End Set
    End Property

    Private _renderSize As SizeF
    Public Property RenderSize As SizeF
        Get
            Return _renderSize
        End Get
        Protected Set(value As SizeF)
            _renderSize = value
        End Set
    End Property

    Public Property Margin As New Thickness(0, 0, 0, 0)

    Public Property VerticalAlignment As VerticalAlignment = VerticalAlignment.Stretch
    Public Property HorizontalAlignment As HorizontalAlignment = HorizontalAlignment.Stretch

    Private _elementVisual As Control
    Public Property ElementVisual As Control
        Get
            Return _elementVisual
        End Get
        Protected Set(value As Control)
            _elementVisual = value
        End Set
    End Property

    Public Sub Measure(availableSize As SizeF)
        If Visibility = Visibility.Visible Then
            Dim sizeWithMargin As SizeF = MeasureCore(availableSize)
            DesiredSize = sizeWithMargin
        Else
            DesiredSize = New Size
        End If
    End Sub

    Protected Function MeasureCore(availableSize As SizeF) As SizeF
        Dim marginWidth = Margin.Left + Margin.Right
        Dim marginHeight = Margin.Top + Margin.Bottom
        Dim availableWidth As Single = availableSize.Width - marginWidth
        Dim availableHeight As Single = availableSize.Height - marginHeight
        LimitSize(availableWidth, availableHeight)
        Dim availableSizeWithoutMargin = New SizeF(availableWidth, availableHeight)
        Dim sizeWithoutMargin = MeasureOverride(availableSizeWithoutMargin)
        Dim desiredWidth As Single = sizeWithoutMargin.Width
        Dim desiredHeight As Single = sizeWithoutMargin.Height
        LimitSize(desiredWidth, desiredHeight)
        Dim sizeWithMargin As New SizeF(
            desiredWidth + marginWidth,
            desiredHeight + marginHeight)
        Return sizeWithMargin
    End Function

    Private Sub LimitSize(ByRef width As Single, ByRef height As Single)
        If Not Double.IsNaN(Me.Width) Then
            width = Me.Width
        End If
        If Not Double.IsNaN(Me.Height) Then
            height = Me.Height
        End If
        If Not Double.IsNaN(MaxWidth) Then
            width = Math.Min(width, MaxWidth)
        End If
        If Not Double.IsNaN(MaxHeight) Then
            height = Math.Min(height, MaxHeight)
        End If
    End Sub

    Protected Overridable Function MeasureOverride(availableSize As SizeF) As SizeF
        Return New Size
    End Function

    Protected Shared ReadOnly EmptyDrawing As New Control

    Public Overridable Sub Arrange(bounds As RectangleF)
        If Visibility = Visibility.Collapsed Then
            ElementVisual = EmptyDrawing
            RenderSize = New Size
            Return
        End If

        RenderSize = ArrangeCore(bounds.Size)

        If EmptyDrawing Is ElementVisual Then
            Return
        End If

        Dim top = bounds.Top + Margin.Top
        Dim left = bounds.Left + Margin.Left
        ElementVisual.Left = CInt(left)
        ElementVisual.Top = CInt(top)
    End Sub

    Protected Function ArrangeCore(finalSize As SizeF) As SizeF
        Dim finalWidth = finalSize.Width
        Dim finalHeight = finalSize.Height
        finalWidth -= Margin.Left + Margin.Right
        finalWidth = Math.Max(0, finalWidth)
        finalHeight -= Margin.Top + Margin.Bottom
        finalHeight = Math.Max(0, finalHeight)
        LimitSize(finalWidth, finalHeight)
        Dim finalSizeWithoutMargin As New SizeF(finalWidth, finalHeight)
        Dim renderSizeCore = ArrangeOverride(finalSizeWithoutMargin)
        Return renderSizeCore
    End Function

    Protected Overridable Function ArrangeOverride(finalSize As SizeF) As SizeF
        ElementVisual = EmptyDrawing
        Return finalSize
    End Function

    Public Overrides Function ToString() As String
        Dim dispName = Name
        If String.IsNullOrEmpty(dispName) Then
            dispName = "<No name>"
        End If
        Return dispName & " As " & Me.GetType.Name
    End Function
End Class
