Module Main

    Sub Main()

        Dim record As Record = New Record
        record.OwnerID = 12345
        record.OwnerName = "Donald J. Santos"

        Dim output As String = record.GetFormattedString

    End Sub

End Module