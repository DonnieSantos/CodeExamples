Public Class Map

    Public Sub Display(Rooms As List(Of List(Of Room)))
        Console.Clear()
        Console.WriteLine()
        PrintHorizontalDivider()
        For i = 0 To 4
            PrintAisle(Rooms(i))
        Next
    End Sub

    Private Sub PrintAisle(ByVal Aisle As List(Of Room))

        For i = 0 To 3

            Console.Write(" ")

            For j = 0 To 4

                Dim room As Room = Aisle(j)
                Dim workers As List(Of Worker) = room.Workers

                If i < workers.Count Then
                    Console.Write("| " & workers(i).Name.PadRight(7) & " ")
                Else
                    Console.Write("|         ")
                End If

            Next

            Console.WriteLine("|")

        Next

        PrintHorizontalDivider()

    End Sub

    Private Sub PrintHorizontalDivider()
        Console.WriteLine(" +---------+---------+---------+---------+---------+")
    End Sub

End Class