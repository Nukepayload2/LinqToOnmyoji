Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Nukepayload2.Linq.Onmyoji

Public Class RecordMacroViewModel
    Inherits Singleton(Of RecordMacroViewModel)
    Implements INotifyPropertyChanged

    ' 标题栏
    Public ReadOnly Property Save As ICommand
    Public ReadOnly Property Undo As ICommand
    Public ReadOnly Property Redo As ICommand
    Public ReadOnly Property OpenFile As ICommand
    Public ReadOnly Property NewFile As ICommand

    Dim _ActiveDocumentName As String
    Public Property ActiveDocumentName As String
        Get
            Return _ActiveDocumentName
        End Get
        Set(value As String)
            If _ActiveDocumentName <> value Then
                _ActiveDocumentName = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ActiveDocumentName)))
            End If
        End Set
    End Property

    ' 大按钮
    Public ReadOnly Property ViewCode As ICommand
    Public ReadOnly Property ViewMacroList As ICommand
    Public ReadOnly Property RecordMacro As ICommand
    Public ReadOnly Property StopRecordMacro As ICommand

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
    Public ReadOnly Property Reset As ICommand
    Public ReadOnly Property DiscardSelected As ICommand
    Public ReadOnly Property EquipmentKinds As New ObservableCollection(Of 御魂图鉴条目)
    Public ReadOnly Property EquipmentKindCandidates As IReadOnlyList(Of 御魂图鉴条目)
    Public ReadOnly Property SelectEquipmentKinds As ICommand
    Public ReadOnly Property Positions As IReadOnlyList(Of FilterIncludeProperty)
    Public ReadOnly Property Stars As IReadOnlyList(Of FilterIncludeProperty)
    Public ReadOnly Property PrimaryProperties As New ObservableCollection(Of FilterIncludeProperty)
    Public ReadOnly Property SecondaryProperties As IReadOnlyList(Of FilterIncludeExcludeProperty)
    Public ReadOnly Property SecondaryCounts As IReadOnlyList(Of FilterIncludeExcludeProperty)

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
