Imports System.Globalization

Public Class InvisibleConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        If TypeOf value IsNot Boolean Then
            Return Visibility.Collapsed
        End If
        If value Then
            Return Visibility.Collapsed
        End If
        Return Visibility.Visible
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return value <> Visibility.Visible
    End Function
End Class
