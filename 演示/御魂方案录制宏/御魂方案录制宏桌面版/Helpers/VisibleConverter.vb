Imports System.Globalization

Public Class VisibleConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        If TypeOf value IsNot Boolean Then
            Return Visibility.Visible
        End If
        If value Then
            Return Visibility.Visible
        End If
        Return Visibility.Collapsed
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return value = Visibility.Visible
    End Function
End Class
