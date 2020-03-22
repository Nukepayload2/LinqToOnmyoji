Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Nukepayload2.Linq.Onmyoji
Imports Nukepayload2.Linq.Onmyoji.Scripting

Public Class RecordMacroViewModel
    Inherits Singleton(Of RecordMacroViewModel)
    Implements INotifyPropertyChanged

    ' 标题栏
    Public ReadOnly Property Save As New SaveDocumentCommand(Me)
    Public ReadOnly Property SaveAs As New SaveDocumentAsCommand(Me)
    Public ReadOnly Property Undo As New UndoCommand(Me)
    Public ReadOnly Property Redo As New RedoCommand(Me)
    Public ReadOnly Property OpenFile As New OpenDocumentCommand(Me)
    Public ReadOnly Property NewFile As New NewDocumentCommand(Me)

    Dim _ActiveDocument As 宏文档
    Public Property ActiveDocument As 宏文档
        Get
            Return _ActiveDocument
        End Get
        Set(value As 宏文档)
            _ActiveDocument = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ActiveDocument)))
        End Set
    End Property

    Dim _YyxData As 痒痒熊快照
    Public Property YyxData As 痒痒熊快照
        Get
            Return _YyxData
        End Get
        Set(value As 痒痒熊快照)
            _YyxData = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(YyxData)))
        End Set
    End Property

    ' 大按钮
    Public ReadOnly Property ViewCode As New ViewCodeCommand(Me)
    Public ReadOnly Property ViewMacroList As New ViewMacroListCommand(Me)
    Public ReadOnly Property RecordMacro As New RecordMacroCommand(Me)
    Public ReadOnly Property StopRecordMacro As New StopRecordMacroCommand(Me)
    Public ReadOnly Property ImportYyxJson As New ImportYyxJsonCommand(Me)

    Dim _IsRecording As Boolean
    Public Property IsRecording As Boolean
        Get
            Return _IsRecording
        End Get
        Set(value As Boolean)
            If _IsRecording <> value Then
                _IsRecording = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(IsRecording)))
            End If
        End Set
    End Property

    ' 左侧
    Dim _ViewDiscarded As Boolean
    Public Property ViewDiscarded As Boolean
        Get
            Return _ViewDiscarded
        End Get
        Set(value As Boolean)
            If _ViewDiscarded <> value Then
                _ViewDiscarded = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ViewDiscarded)))
            End If
        End Set
    End Property

    Dim _ViewingEquipments As IReadOnlyList(Of 御魂)
    Public Property ViewingEquipments As IReadOnlyList(Of 御魂)
        Get
            Return _ViewingEquipments
        End Get
        Set(value As IReadOnlyList(Of 御魂))
            If _ViewingEquipments IsNot value Then
                _ViewingEquipments = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ViewingEquipments)))
            End If
        End Set
    End Property

    Public ReadOnly Property SortEquipments As New SortEquipmentsCommand(Me)

    ' 右侧
    Public ReadOnly Property Reset As New ResetFiltersCommand(Me)
    Public ReadOnly Property ApplyFiltersAndDiscard As New ApplyFiltersAndDiscardCommand(Me)
    Public ReadOnly Property EquipmentKinds As New ObservableCollection(Of 御魂图鉴条目)
    Public ReadOnly Property EquipmentKindCandidates As IReadOnlyList(Of 御魂图鉴条目) = 御魂图鉴.所有条目
    Public ReadOnly Property PickEquipmentKinds As New PickEquipmentKindsCommand(Me)
    Public ReadOnly Property Positions As IReadOnlyList(Of FilterIncludeProperty) = {
        New FilterIncludeProperty("壹"),
        New FilterIncludeProperty("贰"),
        New FilterIncludeProperty("叁"),
        New FilterIncludeProperty("肆"),
        New FilterIncludeProperty("伍"),
        New FilterIncludeProperty("陆")
    }

    Public ReadOnly Property Stars As IReadOnlyList(Of FilterIncludeProperty) = {
        New FilterIncludeProperty("1星"),
        New FilterIncludeProperty("2星"),
        New FilterIncludeProperty("3星"),
        New FilterIncludeProperty("4星"),
        New FilterIncludeProperty("5星"),
        New FilterIncludeProperty("6星")
    }

    Public ReadOnly Property PrimaryProperties As IReadOnlyList(Of FilterIncludePropertyWithVisibility) = {
        New FilterIncludePropertyWithVisibility("攻击"), ' 1
        New FilterIncludePropertyWithVisibility("攻击加成"), ' 246
        New FilterIncludePropertyWithVisibility("防御"), ' 3
        New FilterIncludePropertyWithVisibility("防御加成"), ' 246
        New FilterIncludePropertyWithVisibility("生命"), ' 5
        New FilterIncludePropertyWithVisibility("生命加成"), ' 246
        New FilterIncludePropertyWithVisibility("速度"), ' 2
        New FilterIncludePropertyWithVisibility("命中"), ' 4
        New FilterIncludePropertyWithVisibility("抵抗"), ' 4
        New FilterIncludePropertyWithVisibility("暴击"), ' 6
        New FilterIncludePropertyWithVisibility("暴击伤害") ' 6
    }

    Public ReadOnly Property SecondaryProperties As IReadOnlyList(Of FilterIncludeExcludeProperty) = {
        New FilterIncludeExcludeProperty("攻击"),
        New FilterIncludeExcludeProperty("攻击加成"),
        New FilterIncludeExcludeProperty("防御"),
        New FilterIncludeExcludeProperty("防御加成"),
        New FilterIncludeExcludeProperty("生命"),
        New FilterIncludeExcludeProperty("生命加成"),
        New FilterIncludeExcludeProperty("速度"),
        New FilterIncludeExcludeProperty("命中"),
        New FilterIncludeExcludeProperty("抵抗"),
        New FilterIncludeExcludeProperty("暴击"),
        New FilterIncludeExcludeProperty("暴击伤害")
    }

    Public ReadOnly Property SecondaryCounts As IReadOnlyList(Of FilterIncludeProperty) = {
        New FilterIncludeProperty("不足2条"),
        New FilterIncludeProperty("2条"),
        New FilterIncludeProperty("3条"),
        New FilterIncludeProperty("4条")
    }

    ' 隐藏命令
    Public ReadOnly Property TryApplyFiltersForCurrentView As New TryApplyFiltersForCurrentViewCommand(Me)

    Public ReadOnly Property HiddenCommandBindings As New HiddenCommandBindingCollection

    Sub New()
        Dim apply = TryApplyFiltersForCurrentView
        With HiddenCommandBindings
            .AddRange(Positions, NameOf(FilterIncludeProperty.IsSelected), apply)
            .AddRange(Stars, NameOf(FilterIncludeProperty.IsSelected), apply)
            .AddRange(PrimaryProperties, NameOf(FilterIncludePropertyWithVisibility.IsSelected), apply)
            .AddRange(SecondaryProperties, NameOf(FilterIncludeExcludeProperty.IncludeProperty), apply)
            .AddRange(SecondaryProperties, NameOf(FilterIncludeExcludeProperty.ExcludeProperty), apply)
            .AddRange(SecondaryCounts, NameOf(FilterIncludeProperty.IsSelected), apply)
        End With
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
