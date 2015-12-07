Module Module1

    Sub Main()

        Console.Write("Enter a number: ")

        Dim number As Integer = Console.ReadLine()

        If number >= 0 Then
            Console.WriteLine("The user entered a non-negative number.")
        Else
            Console.WriteLine("The user entered a negative number.")
        End If

        Console.ReadKey()

    End Sub

End Module