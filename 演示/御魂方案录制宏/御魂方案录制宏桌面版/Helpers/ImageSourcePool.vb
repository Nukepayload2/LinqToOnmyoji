Imports Nukepayload2.Linq.Onmyoji

Public Class ImageSourcePool
    Private ReadOnly _images As New Dictionary(Of String, ImageSource)
    Private ReadOnly _packAssets As String =
        "pack://application:,,,/御魂方案录制宏桌面版;component/Assets/"
    Public Function FromEquipmentId(type As 御魂种类) As ImageSource
        Const DirName = "Equipments"
        Dim imgName = type & ".png"
        Dim imagePath = String.Concat(_packAssets, DirName, "/", imgName)
        Dim imgSrc As ImageSource = Nothing
        If Not _images.TryGetValue(imagePath, imgSrc) Then
            imgSrc = New BitmapImage(New Uri(imagePath, UriKind.Absolute))
            _images.Add(imagePath, imgSrc)
        End If
        Return imgSrc
    End Function
End Class
