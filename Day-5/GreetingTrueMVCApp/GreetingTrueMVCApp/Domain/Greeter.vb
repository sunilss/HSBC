Public Class Greeter

    Dim dateService As IDateService

    Public Sub New(dateService As IDateService)
        Me.dateService = dateService

    End Sub

    Public Function Greet(ByVal input As GreetModel) As String
        Dim fullname = input.FirstName + " " + input.LastName
        If (Me.dateService.GetCurrentDateTime.Hour < 18) Then
            Return "Good Day " + fullname
        Else
            Return "Good Evening " + fullname
        End If

    End Function
End Class
