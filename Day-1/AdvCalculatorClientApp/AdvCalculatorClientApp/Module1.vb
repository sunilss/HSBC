Imports AdvCalculatorClientApp.ServiceProxies

Module Module1

    Sub Main()
        Dim client As New ServiceProxies.AdvCalculatorClient()
        'Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Add"}))
        'Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Subtract"}))
        'Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Multiply"}))
        'Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Divide"}))

        Dim request As New MathRequest() With {.Number1 = 100, .Number2 = 200}
        Dim result As List(Of MathResult) = client.ProcessAll(request)
        For Each r In result
            Console.WriteLine(r)
        Next
        Console.ReadLine()
    End Sub

End Module

Namespace ServiceProxies
    Partial Public Class MathResult
        Public Overrides Function ToString() As String

            Return String.Format("Number1 = {0}, Number2 = {1}, Operation = {2}, Result={3}", Me.Number1, Me.Number2, Me.Operation, Me.Result)
        End Function
    End Class
End Namespace

