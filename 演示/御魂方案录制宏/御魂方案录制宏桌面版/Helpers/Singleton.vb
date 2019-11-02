Imports System.Threading

Public Class Singleton(Of T As {New, Singleton(Of T)})
    Private Shared s_instance As T
    Private Shared ReadOnly s_lock As New Object

    Public Shared ReadOnly Property Instance As T
        Get
            If Volatile.Read(s_instance) IsNot Nothing Then
                Return Volatile.Read(s_instance)
            End If
            SyncLock s_lock
                If Volatile.Read(s_instance) Is Nothing Then
                    Volatile.Write(s_instance, New T)
                End If
            End SyncLock
            Return Volatile.Read(s_instance)
        End Get
    End Property
End Class
