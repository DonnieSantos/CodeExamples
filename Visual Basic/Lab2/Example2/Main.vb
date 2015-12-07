Module Main

    Sub Main()

        Dim P1 As Point = New Point
        P1.X = 5.5
        P1.Y = 10.2
        P1.Z = 7.9

        Dim P1Copy As Point = New Point
        P1Copy.X = P1.X
        P1Copy.Y = P1.Y
        P1Copy.Z = P1.Z

        Dim P1Reference As Point
        P1Reference = P1

        Dim result1 As Boolean = P1.Equals(P1Copy)
        Dim result2 As Boolean = P1.Equals(P1Reference)

    End Sub

End Module