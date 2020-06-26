Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Windows.Media.Animation
Imports Nukepayload2.Linq.Onmyoji

Public Class EquipmentPickerFlyout

    Private _candidateListCache As CandidateItem()
    Private _candidateListCacheIndexByType As Dictionary(Of 御魂种类, CandidateItem)

    Private Sub UpdateCandidateList(dataSource As IReadOnlyList(Of 御魂))
        If _candidateListCache Is Nothing Then
            _candidateListCache = Aggregate itm In 御魂图鉴.所有条目
                                  Select New CandidateItem(itm.Id, 0) Into ToArray
            _candidateListCacheIndexByType = Aggregate cac In _candidateListCache
                                             Into ToDictionary(cac.Type)
            LstCandidates.ItemsSource = _candidateListCache
        End If
        UpdateEquipmentCount(_candidateListCache, dataSource)
    End Sub

    Private Sub UpdateEquipmentCount(candidateListCache As CandidateItem(),
                                     dataSource As IReadOnlyList(Of 御魂))
        For Each cand In candidateListCache
            cand.Count = 0
        Next
        For Each equ In dataSource
            Dim cand = _candidateListCacheIndexByType(equ.种类)
            cand.Count += 1
        Next
    End Sub

    Private _status As FlyoutStatus

    Public Async Function ShowAsync(dataSource As IReadOnlyList(Of 御魂)) As Task(Of IReadOnlyList(Of 御魂种类))
        If _status <> FlyoutStatus.Hidden Then
            Throw New InvalidOperationException("检测到重复调用 ShowAsync")
        End If
        _status = FlyoutStatus.Shown
        UpdateCandidateList(dataSource)
        Visibility = Visibility.Visible
        Await ShowAnimAsync()
        Await WaitForUserInputAsync()
        Dim result = GetFilterInfo()
        Await HideAnimAsync()
        _status = FlyoutStatus.Hidden
        Return result
    End Function

    Private Function GetFilterInfo() As IReadOnlyList(Of 御魂种类)
        Return Aggregate item In LstCandidates.SelectedItems.OfType(Of CandidateItem)
               Where item.Count > 0
               Select item.Type Into ToArray
    End Function

    Private Async Function ShowAnimAsync() As Task
        Dim anim As Storyboard = Resources!EntryStoryboard
        anim.Begin()
        Await Task.Delay(300)
    End Function

    Private Async Function HideAnimAsync() As Task
        Dim anim As Storyboard = Resources!ExitStoryboard
        anim.Begin()
        Await Task.Delay(300)
    End Function

    Private Async Function WaitForUserInputAsync() As Task
        Do While _status = FlyoutStatus.Shown
            Await Task.Delay(10)
        Loop
    End Function

    Private Enum FlyoutStatus
        Hidden
        Shown
        Cancel
        Ok
    End Enum

    Private Class CandidateItem
        Implements INotifyPropertyChanged

        Public Sub New(type As 御魂种类, count As Integer)
            _Type = type
            _Count = count
        End Sub

        Public ReadOnly Property Type As 御魂种类

        Dim _Count As Integer
        Public Property Count As Integer
            Get
                Return _Count
            End Get
            Set(value As Integer)
                _Count = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Count)))
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class
End Class
