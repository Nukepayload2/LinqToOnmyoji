Imports Nukepayload2.Linq.Onmyoji

Public Class EquipmentPickerFlyout

    Public Property Equipments As IReadOnlyList(Of 御魂)
        Get
            Return GetValue(EquipmentsProperty)
        End Get
        Set
            SetValue(EquipmentsProperty, Value)
        End Set
    End Property
    Public Shared ReadOnly EquipmentsProperty As DependencyProperty =
                           DependencyProperty.Register(NameOf(Equipments),
                           GetType(IReadOnlyList(Of 御魂)), GetType(EquipmentPickerFlyout),
                           New PropertyMetadata(Nothing))

    Private _candidateListCache As CandidateItem()

    Private Sub UpdateCandidateList()
        If _candidateListCache Is Nothing Then
            _candidateListCache = Aggregate itm In 御魂图鉴.所有条目
                                  Select New CandidateItem(itm.Id, 0) Into ToArray
            LstCandidates.ItemsSource = _candidateListCache
        End If
        UpdateEquipmentCount(_candidateListCache)
    End Sub

    Private Sub UpdateEquipmentCount(candidateListCache As CandidateItem())

    End Sub

    Private Sub EquipmentPickerFlyout_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        UpdateCandidateList()
    End Sub

    Public Class CandidateItem
        Public Sub New(type As 御魂种类, count As Integer)
            Me.Type = type
            Me.Count = count
        End Sub

        Public Property Type As 御魂种类
        Public Property Count As Integer
    End Class
End Class
