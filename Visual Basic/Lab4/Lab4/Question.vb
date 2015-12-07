Public Class Question

    Public Shared Function AskForString(prompt As String) As String
        Console.Write(FormatPrompt(prompt))
        Return Console.ReadLine()
    End Function

    Public Shared Function AskForInteger(prompt As String) As Integer
        Return Integer.Parse(prompt)
    End Function

    Public Shared Function AskForBoolean(prompt As String) As Boolean
        Return AskForString(prompt).ToUpper().StartsWith("Y")
    End Function

    Private Shared Prefix As String

    Public Shared Sub SetPromptPrefix(prefix As String)
        Question.Prefix = prefix
    End Sub

    Private Shared Function FormatPrompt(prompt As String) As String

        If Not (String.IsNullOrEmpty(Prefix)) Then
            prompt = Prefix + " " + prompt
        End If

        prompt = prompt.PadRight(25)
        prompt += ": "

        Return prompt

    End Function

End Class