Namespace GreetingTrueMVCApp
    Public Class GreetingController
        Inherits System.Web.Mvc.Controller

        Dim dateServiceObject As IDateService
        Dim greeterObject As Greeter

        Public Sub New()
            dateServiceObject = New DateService()
            greeterObject = New Greeter(dateServiceObject)
        End Sub

        Public Sub New(ds As IDateService, greeterObj As Greeter)
            dateServiceObject = ds
            greeterObject = greeterObj
        End Sub


        Public Function Greet(ByVal firstName As String, ByVal lastName As String) As ViewResult

            Dim greetModel As New GreetModel With {.FirstName = firstName, .LastName = lastName}
            greetModel.Validate()
            If (greetModel.ErrorMessages.Count <> 0) Then
                Return View("GreetInput", greetModel)
            End If

            ViewData("Message") = greeterObject.Greet(firstName, lastName)
            If (dateServiceObject.GetCurrentDateTime.Hour < 18) Then
                Return View("GoodDayView")
            Else
                Return View("GoodEveningView")
            End If

        End Function


        Public Function GreetInput() As ActionResult
            Dim model As New GreetModel
            Return View(model)
        End Function
    End Class

    Public Class GreetingDataValidator
        
    End Class

    
End Namespace

