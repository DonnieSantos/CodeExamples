Public Class Room

    Public Property North As Room
    Public Property South As Room
    Public Property East As Room
    Public Property West As Room
    Public Property Workers As List(Of Worker)

    Public Sub New()
        Me.Workers = New List(Of Worker)
    End Sub

    Public Function CreateNewWorker(Name As String) As Worker
        Dim Worker As Worker = New Worker(Name, Me)
        Me.Workers.Add(Worker)
        Return Worker
    End Function

    Public Function GetRandomExit() As Room
        Dim AvailableExits As List(Of Room) = New List(Of Room)
        If Me.North IsNot Nothing Then availableExits.Add(Me.North)
        If Me.South IsNot Nothing Then availableExits.Add(Me.South)
        If Me.East IsNot Nothing Then availableExits.Add(Me.East)
        If Me.West IsNot Nothing Then availableExits.Add(Me.West)
        Return AvailableExits(CInt(Math.Ceiling(Rnd() * (AvailableExits.Count))) - 1)
    End Function

End Class