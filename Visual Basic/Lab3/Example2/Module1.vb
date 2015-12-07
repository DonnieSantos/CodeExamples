Module Module1

    Sub Main()

        Console.Write("Enter a number between 1 and 1000: ")

        Dim number As Integer = Console.ReadLine()

        If number < 1 Or number > 1000 Then
            Console.WriteLine("That number is not between 1 and 1000!")
        Else
            If (number >= 666) Then
                Console.WriteLine("High")
            ElseIf number >= 333 Then
                Console.WriteLine("Medium")
            Else
                Console.WriteLine("Low")
            End If
        End If

        Console.ReadKey()

    End Sub

End Module