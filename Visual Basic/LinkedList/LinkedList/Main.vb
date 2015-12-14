Module Main

    Sub Main()

        Dim list As LinkedList = New LinkedList(New Node("D"))

        list.Append(New Node("E"))
        list.Append(New Node("F"))
        
        list.InsertNodeAtPosition(New Node("A"), 0)
        list.InsertNodeAtPosition(New Node("B"), 1)
        list.InsertNodeAtPosition(New Node("C"), 2)
        list.InsertNodeAtPosition(New Node("G"), 6)

        list.Print()

        Console.ReadLine()

    End Sub

End Module