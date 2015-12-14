Public Class Node

    Private _value As String
    Private _next As Node

    Public Sub New(NodeValue As String)
        _value = NodeValue
    End Sub

    Public Function GetValue As String
        Return _value
    End Function

    Public Function GetNext() As Node
        Return _next
    End Function

    Public Sub SetNext(nextNode As Node)
        _next = nextNode
    End Sub

End Class