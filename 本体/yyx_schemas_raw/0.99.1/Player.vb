﻿' Generated by Xamasoft JSON Class Generator
' http://www.xamasoft.com/json-class-generator

Imports System
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Global.Example

    Public Class Player

        <JsonProperty("id")>
        Public Property Id As Integer

        <JsonProperty("level")>
        Public Property Level As Integer

        <JsonProperty("name")>
        Public Property Name As String

        <JsonProperty("server_id")>
        Public Property ServerId As Integer
    End Class

End Namespace
