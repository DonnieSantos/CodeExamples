Public Class Office

    Public Property Workers As List(Of Worker)
    Public Property Rooms As List(Of List(Of Room))

    Public Sub New()
        CreateRooms()
        ConnectRooms()
        AddWorkers()
    End Sub

    Private Sub CreateRooms()
        Rooms = New List(Of List(Of Room))
        For i = 0 To 4
            Dim Aisle As List(Of Room) = New List(Of Room)
            For j = 0 To 4
                Aisle.Add(New Room())
            Next
            Rooms.Add(Aisle)
        Next
    End Sub

    Private Sub ConnectRooms()
        For i = 0 To 4
            For j = 0 To 4
                If i > 0 Then Rooms(i)(j).North = Rooms(i - 1)(j)
                If j > 0 Then Rooms(i)(j).West = Rooms(i)(j - 1)
                If i < 4 Then Rooms(i)(j).South = Rooms(i + 1)(j)
                If j < 4 Then Rooms(i)(j).East = Rooms(i)(j + 1)
            Next
        Next
    End Sub

    Private Sub AddWorkers()
        Workers = New List(Of Worker)
        Workers.Add(Rooms(0)(0).CreateNewWorker("Michael"))
        Workers.Add(Rooms(0)(0).CreateNewWorker("Dwight"))
        Workers.Add(Rooms(0)(0).CreateNewWorker("Jim"))
        Workers.Add(Rooms(0)(0).CreateNewWorker("Pam"))
    End Sub

    Public Sub MoveWorkers()
        For Each Worker In Workers
            Worker.Move()
        Next
    End Sub

End Class