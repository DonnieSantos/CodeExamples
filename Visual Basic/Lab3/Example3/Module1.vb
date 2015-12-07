Module Module1

    Sub Main()

        Console.Write("Enter a number: ")
        Dim number As Integer = Console.ReadLine()
        Dim result As String = If(number >= 0, "non-negative", "negative")
        Console.WriteLine("The user entered a " & result & " number.")
        Console.ReadKey()

    End Sub

End Module