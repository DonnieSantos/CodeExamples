Public Class LinkedList

    Private _root As Node
    Private _last As Node
    Private _size As Integer

    Public Sub New(node As Node)
        _root = node
        _last = node
        _size = 1
    End Sub

    Public Sub Append(node As Node)
        _last.SetNext(node)
        _last = node
        _size = _size + 1
    End Sub

    Public Sub InsertNodeAtPosition(node As Node, position As Integer)
        
        Select Case position

            Case 0
                InsertNewRoot(node)
            Case _size
                Append(node)
            Case Else
                Insert(node, position)

        End Select

    End Sub

    Private Sub InsertNewRoot(node As Node)
        node.SetNext(_root)
        _root = node
        _size = _size + 1
    End Sub

    Private Sub Insert(node As Node, index As Integer)
        Dim targetNode As Node = GetNode(index-1, False)
        node.SetNext(targetNode.GetNext())
        targetNode.SetNext(node)
        _size = _size + 1
    End Sub

    Public Sub Print()
        GetNode(_size, True)
    End Sub

    Private Function GetNode(Position As Integer, ShouldPrint As Boolean) As Node
        
        Dim walker As Node = _root

        For i = 1 to Position
            If ShouldPrint Then Console.Write(walker.GetValue() & " ")
            walker = walker.GetNext()
        Next

        Return walker

    End Function

End Class