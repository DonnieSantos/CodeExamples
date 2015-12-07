Public Class Record

    Public OwnerID As Integer
    Public OwnerName As String

    Public Function GetFormattedString()
        Dim formattedID As String = "[" & Me.OwnerID & "]"
        Dim formattedString As String = formattedID & " " & Me.OwnerName
        Return formattedString
    End Function

End Class