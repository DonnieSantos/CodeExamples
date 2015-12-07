Public Class Worker

    Public Property Name As String
    Public Property Room As Room

    Public Sub New(Name As String, Room As Room)
        Me.Name = Name
        Me.Room = Room
    End Sub

    Public Sub Move()
        Dim destination As Room = Me.Room.GetRandomExit()
        Me.Room.Workers.Remove(Me)
        destination.Workers.Add(Me)
        Me.Room = destination
    End Sub

End Class