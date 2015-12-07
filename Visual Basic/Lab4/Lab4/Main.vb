Module Main

    Sub Main()

        Dim averageAge As AverageAge = New AverageAge()
        averageAge.AddPerson(Person.Create(""))
        averageAge.AddPerson(Person.Create(""))
        averageAge.AddPerson(Person.Create(""))
        Console.WriteLine("Average Age: " + averageAge.Get())

    End Sub

End Module