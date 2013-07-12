
Public Class GreetModel
    Public Property FirstName As String
    Public Property LastName As String
    Public Property ErrorMessages As New Dictionary(Of String, String)
    Public Sub Validate()

        If (FirstName = String.Empty) Then
            ErrorMessages.Add("FirstName", "First Name cannot be empty")
        End If
        If (LastName = String.Empty) Then
            ErrorMessages.Add("LastName", "Last Name cannot be empty")
        End If

    End Sub
End Class
