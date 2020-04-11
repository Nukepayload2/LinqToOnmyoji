﻿Imports System.Collections.ObjectModel
Imports Microsoft.Win32
Imports Nukepayload2.Linq.Onmyoji

Public Class ImportYyxJsonCommand
    Inherits AsyncCommandBase

    Private ReadOnly _viewModel As RecordMacroViewModel

    Public Sub New(recordMacroViewModel As RecordMacroViewModel)
        _viewModel = recordMacroViewModel
    End Sub

    Private ReadOnly _openDataDialog As New OpenFileDialog With {
        .Filter = "JSON 文件|*.json"
    }

    Protected Overrides Async Function ExecuteAsync(parameter As Object) As Task
        If _openDataDialog.ShowDialog Then
            Dim yyxJsonFile = _openDataDialog.FileName
            Try
                Await Task.Yield
                Dim snap = Await Task.Run(Function() 痒痒熊快照.加载Json文件(yyxJsonFile))
                _viewModel.YyxData = snap
                Dim equipments = snap.数据.御魂
                Dim useBlockedLoad = False
                If useBlockedLoad Then
                    Dim filterResult As New ObservableCollection(Of 御魂)
                    _viewModel.ViewingEquipments = filterResult
                    Const BlockSize = 100
                    For i = 0 To equipments.Length - 1
                        filterResult.Add(equipments(i))
                        If i Mod BlockSize = 0 Then
                            Await Task.Delay(10)
                        End If
                    Next
                Else
                    _viewModel.ViewingEquipments = equipments
                End If
            Catch ex As Exception
                _viewModel.YyxData = Nothing
                MsgBox(ex.Message, vbExclamation, "加载快照失败")
            End Try
        End If
    End Function
End Class
