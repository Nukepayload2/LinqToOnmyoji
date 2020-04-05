Public Class CachedJadeControlArray
    Inherits Image

    Public Property JadeCount As Integer
        Get
            Return GetValue(JadeCountProperty)
        End Get
        Set
            SetValue(JadeCountProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly JadeCountProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(JadeCount),
                           GetType(Integer), GetType(CachedJadeControlArray),
                           New PropertyMetadata(0, AddressOf OnJadeCountChanged))

    Private Shared Sub OnJadeCountChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim inst As CachedJadeControlArray = d
        Dim newVal As Integer = e.NewValue
        newVal = Math.Max(1, newVal)
        newVal = Math.Min(6, newVal)
        inst.Source = s_jadeCache(newVal)
    End Sub

    Protected Overrides Function MeasureOverride(constraint As Size) As Size
        Dim srcBmp = TryCast(Source, RenderTargetBitmap)
        If srcBmp Is Nothing Then
            Return New Size
        End If
        Return New Size(Math.Min(srcBmp.Width, constraint.Width),
                        Math.Min(srcBmp.Height, constraint.Height))
    End Function

    Private Shared ReadOnly s_jadeCache As New JadeBitmapCacheCollection

    Private Class JadeBitmapCacheCollection
        Private ReadOnly _jades(5) As ImageSource

        Sub DirtyAll()
            For i = 0 To _jades.Length - 1
                _jades(i) = Nothing
            Next
        End Sub

        Default ReadOnly Property Jade(count As Integer) As ImageSource
            Get
                Dim index = count - 1
                Dim result As ImageSource = _jades(index)
                If result Is Nothing Then
                    result = GenerateJadeImage(count)
                    _jades(index) = result
                End If
                Return result
            End Get
        End Property

        Private Function GenerateJadeImage(count As Integer) As ImageSource
            Dim jadeArr As New JadeControlArray With {
                .JadeCount = count
            }

            Dim maxSize As New Size(200, 100)
            jadeArr.Measure(maxSize)
            Dim desiredSize = jadeArr.DesiredSize
            jadeArr.Arrange(New Rect(0, 0, desiredSize.Width, desiredSize.Height))

            ' DPI 缩放最高支持 300%
            ' 如果有用户提需求可以改成处理 DpiChanged 事件获取 Dpi。
            Const MaxDpiScale = 3
            Const DpiXY = 96 * MaxDpiScale
            Dim rt As New RenderTargetBitmap(desiredSize.Width * MaxDpiScale,
                                             desiredSize.Height * MaxDpiScale,
                                             DpiXY, DpiXY, PixelFormats.Pbgra32)
            rt.Render(jadeArr)
            'Dim dbgWnd As New Window
            'Dim img As New Image With {.Source = rt}
            'dbgWnd.Content = img
            'dbgWnd.Show()
            Return rt
        End Function
    End Class

End Class
