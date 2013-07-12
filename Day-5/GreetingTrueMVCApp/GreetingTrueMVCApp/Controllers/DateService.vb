
Namespace GreetingTrueMVCApp
    Public Class DateService
        Implements IDateService


        Public Function GetCurrentDateTime() As Date Implements IDateService.GetCurrentDateTime
            Return DateAndTime.Now

        End Function
    End Class
End Namespace
