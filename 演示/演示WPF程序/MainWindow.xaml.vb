Imports Nukepayload2.Linq.Onmyoji
Imports Nukepayload2.Linq.Onmyoji.Utilities
Imports Nukepayload2.UI.Win32

<Assembly: DisableDpiAwareness>

Class MainWindow
    Private Sub TitleBarDragElement_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles TitleBarDragElement.PreviewMouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As RoutedEventArgs) Handles BtnAbout.Click
        MsgBox("作者: 
B站、GitHub、百度贴吧、微博：Nukepayload2。
阴阳师：依偎相守#2723416
攻略：
B站 解说七老爷", vbInformation, "关于")
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Private Sub MainWindow_SourceInitialized(sender As Object, e As EventArgs) Handles Me.SourceInitialized
        Dim windowCompositionFactory As New WindowCompositionFactory
        If Win32ApiInformation.IsWindowAcrylicApiPresent OrElse Win32ApiInformation.IsAeroGlassApiPresent Then
            Dim composition = windowCompositionFactory.TryCreateForCurrentView
            If composition?.TrySetBlur(Me, True) Then
                TitleBar.Background = New SolidColorBrush(Color.FromArgb(&H99, &HFF, &HFF, &HFF))
                ClientArea.Background = New SolidColorBrush(Color.FromArgb(&HCC, &HFF, &HFF, &HFF))
                Background = Brushes.Transparent
            End If
        End If
        If Win32ApiInformation.IsProcessDpiAwarenessApiPresent Then
            DpiAwareness = ProcessDpiAwareness.PerMonitorDpiAware
        End If
    End Sub

    Private Async Sub BdrFileDrop_Drop(sender As Object, e As DragEventArgs) Handles BdrFileDrop.Drop
        Dim 输入文件 = TryCast(e.Data.GetData(DataFormats.FileDrop), String())?.FirstOrDefault
        TxtOut.Text = String.Empty
        BdrFileDrop.IsEnabled = False
        Try
            If 输入文件 = Nothing OrElse Not IO.File.Exists(输入文件) Then
                TxtOut.AppendText("需要拖放痒痒熊快照 Json 文件" & vbCrLf)
                Return
            End If

            TxtOut.AppendText("载入中..." & vbCrLf)
            Dim 快照 = Await Task.Run(Function() 痒痒熊快照.加载Json文件(输入文件))

            Dim 六星御魂 = From s In 快照.数据.御魂 Where s.星级 = 6 AndAlso s.已弃置 = False

            TxtOut.Text = String.Empty
            TxtOut.AppendText($"整理前六星御魂数量: {六星御魂.Count}" & vbCrLf)
            Await Task.Run(Sub() 御魂整理方案.七老爷三周年庆御魂整理方案(快照))
            TxtOut.AppendText($"整理后六星御魂数量: {六星御魂.Count}" & vbCrLf)
            TxtOut.AppendText("操作成功完成。")
        Catch ex As Exception
            TxtOut.AppendText($"错误信息: {ex}")
            MsgBox($"出现错误 {ex.Message}, 请检查拖放的文件。如果问题持续存在，请联系作者。", vbExclamation, "错误")
        Finally
            BdrFileDrop.IsEnabled = True
        End Try
    End Sub

    Private Sub BdrFileDrop_DragEnter(sender As Object, e As DragEventArgs) Handles BdrFileDrop.DragEnter
        e.Effects = DragDropEffects.Link
    End Sub
End Class
