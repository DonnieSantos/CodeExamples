Module Module1

    Sub Main()

        Dim firstName As String
        Dim middleInitial As Char
        Dim lastName As String
        Dim fullName As String
        Dim age As Integer
        Dim isCitizen As Boolean
        Dim canVote As Boolean
        Dim heightFeet As Integer
        Dim heightInches As Decimal
        Dim totalHeightCM As Decimal

        firstName = "Donald"
        middleInitial = "J"
        lastName = "Santos"
        fullName = firstName & " " & middleInitial & ". " & lastName

        age = 36
        heightFeet = 6
        heightInches = 1.25
        Dim totalHeightInches As Decimal = (heightFeet * 12) + heightInches
        totalHeightCM = 2.54 * totalHeightInches

        isCitizen = True
        Dim isOldEnoughToVote As Boolean = age >= 18
        canVote = isCitizen And isOldEnoughToVote

    End Sub

End Module