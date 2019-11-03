Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Nukepayload2.Linq.Onmyoji
Imports Nukepayload2.Linq.Onmyoji.Scripting

Public Class RecordMacroViewModel
    Inherits Singleton(Of RecordMacroViewModel)
    Implements INotifyPropertyChanged

    ' 标题栏
    Public ReadOnly Property Save As New SaveDocumentCommand(Me)
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

    ' 大按钮
    Public ReadOnly Property ViewCode As New ViewCodeCommand(Me)
    Public ReadOnly Property ViewMacroList As New ViewMacroListCommand(Me)
    Public ReadOnly Property RecordMacro As New RecordMacroCommand(Me)
    Public ReadOnly Property StopRecordMacro As New StopRecordMacroCommand(Me)

    Dim _IsRecording As Boolean = True
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

    Dim _SelectAll As Boolean
    Public Property SelectAll As Boolean
        Get
            Return _SelectAll
        End Get
        Set(value As Boolean)
            If _SelectAll <> value Then
                _SelectAll = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(SelectAll)))
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

    ' 右侧
    Public ReadOnly Property Reset As New ResetFiltersCommand(Me)
    Public ReadOnly Property DiscardSelected As New ApplyFiltersCommand(Me)
    Public ReadOnly Property EquipmentKinds As New ObservableCollection(Of 御魂图鉴条目)
    Public ReadOnly Property EquipmentKindCandidates As IReadOnlyList(Of 御魂图鉴条目)
    Public ReadOnly Property Positions As IReadOnlyList(Of FilterIncludeProperty)
    Public ReadOnly Property Stars As IReadOnlyList(Of FilterIncludeProperty)
    Public ReadOnly Property PrimaryProperties As New ObservableCollection(Of FilterIncludeProperty)
    Public ReadOnly Property SecondaryProperties As IReadOnlyList(Of FilterIncludeExcludeProperty)
    Public ReadOnly Property SecondaryCounts As IReadOnlyList(Of FilterIncludeExcludeProperty)

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
