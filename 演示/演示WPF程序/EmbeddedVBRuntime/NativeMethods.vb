Class NativeMethods
    ' int MessageBox(
    '   HWND    hWnd,
    '   LPCTSTR lpText,
    '   LPCTSTR lpCaption,
    '   UINT    uType
    ' );
    Declare Unicode Function MessageBox Lib "user32" Alias "MessageBoxW" (
        hwnd As IntPtr,
        text As String,
        caption As String,
        type As MsgBoxStyle) As MsgBoxResult

    ' HWND GetActiveWindow();
    Declare Function GetActiveWindow Lib "user32" () As IntPtr
End Class
