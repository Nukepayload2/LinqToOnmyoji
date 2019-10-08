Module Interaction
    Function MsgBox(
            prompt As Object,
            Optional styles As MsgBoxStyle = vbOKOnly,
            Optional caption As Object = Nothing) As MsgBoxResult

        Dim promptText = CStr(prompt)
        Dim captionText = If(CStr(caption), Reflection.Assembly.GetCallingAssembly.GetName.Name)
        Dim parentWindow = NativeMethods.GetActiveWindow
        Dim result = NativeMethods.MessageBox(parentWindow, promptText, captionText, styles)
        Return result
    End Function
End Module
