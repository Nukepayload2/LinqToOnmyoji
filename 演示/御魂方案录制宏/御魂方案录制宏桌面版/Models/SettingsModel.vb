Imports System.IO

Class SettingsModel
    Public Property RecentFiles As IReadOnlyList(Of String)

    Public Property IsLoaded As Boolean

    Const SaveFileName = "御魂方案录制设置.xml"

    Sub Load()
        If Not File.Exists(SaveFileName) Then
            Return
        End If
        Dim doc = XDocument.Load(SaveFileName)
        RecentFiles = (From ele In doc.Root.<RecentFiles>.<File>
                       Select ele.@Value).ToArray
        IsLoaded = True
    End Sub

    Sub Save()
        Dim docRoot =
            <Settings Version="1.0">
                <RecentFiles>
                    <%= From f In If(RecentFiles, Array.Empty(Of String))
                        Select <File><%= f %></File> %>
                </RecentFiles>
            </Settings>
        Dim doc As New XDocument(docRoot)
        doc.Save(SaveFileName)
    End Sub
End Class
