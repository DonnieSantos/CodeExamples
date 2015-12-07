Module Main

    Dim Map As Map
    Dim TheOffice As Office

    Sub Main()
        Map = New Map()
        TheOffice = New Office()
        Dim timer As New System.Timers.Timer
        timer.AutoReset = True
        timer.Interval = 1000
        AddHandler timer.Elapsed, AddressOf TickTock
        timer.Start()
        Do While True
        Loop
    End Sub

    Sub TickTock()
        TheOffice.MoveWorkers()
        Map.Display(theOffice.Rooms)
    End Sub

End Module