Imports System.Collections.ObjectModel

''' <summary>
''' 描述录制时操作的影响
''' </summary>
Public MustInherit Class 宏录制界面操作行为
    Public MustOverride Sub 执行()
    Public MustOverride Sub 撤销()
End Class

''' <summary>
''' 用于记录当前操作的信息
''' </summary>
Public Class 宏录制界面操作文档
    Public ReadOnly Property 操作 As New ObservableCollection(Of 宏录制界面操作信息)
End Class

''' <summary>
''' 用于记录当前操作的信息
''' </summary>
Public Class 宏录制界面操作信息
    ''' <summary>
    ''' 操作的类型
    ''' </summary>
    Public Property 类型 As 宏录制界面操作类型
    ''' <summary>
    ''' 御魂或者属性的名称
    ''' </summary>
    Public Property 名称 As String
End Class

Public Enum 宏录制界面操作类型
    未知
    切换到已弃置
    切换到待整理
    重置
    全选并弃置
    勾选御魂类型
    去掉御魂类型
    清空御魂类型
    勾选位置
    去掉位置
    勾选星级
    去掉星级
    勾选主属性
    去掉主属性
    勾选副属性
    排除副属性
    清除副属性
    勾选副属性条数
    去掉副属性条数
End Enum
