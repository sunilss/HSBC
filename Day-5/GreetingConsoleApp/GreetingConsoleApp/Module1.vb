Module Module1

    Sub Main()
        Console.WriteLine("Enter your name : ")
        Dim name = Console.ReadLine()
        Dim dService = New DateService()
        Dim greeter = New Greeter(dService)
        Console.WriteLine(greeter.Greet(name))
        Console.ReadLine()
    End Sub

End Module

Public Class Greeter
    Dim dService As IDateService
    Public Sub New(ByVal dService As IDateService)
        Me.dService = dService
    End Sub

    Public Function Greet(ByVal name As String) As String
        If (Me.dService.GetCurrentDateTime.Hour < 16) Then
            Return String.Format("Good Day {0}", name)
        Else
            Return String.Format("Good Evening {0}", name)
        End If
    End Function
End Class

Public Interface IDateService
    Function GetCurrentDateTime() As DateTime
End Interface

Public Class DateService
    Implements IDateService

    Public Function GetCurrentDateTime1() As Date Implements IDateService.GetCurrentDateTime
        Return DateAndTime.Now
    End Function
End Class