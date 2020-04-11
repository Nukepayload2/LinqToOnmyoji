Imports System.Runtime.CompilerServices

Module Utils

    <Extension>
    Sub AppendLine(txtControl As TextBox, text As String)
        txtControl.AppendText(text)
        txtControl.AppendText(Environment.NewLine)
    End Sub
End Module
