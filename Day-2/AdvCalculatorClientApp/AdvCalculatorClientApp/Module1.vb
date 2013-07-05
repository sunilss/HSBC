Imports AdvCalculatorClientApp.ServiceProxies
Imports System.ServiceModel

Module Module1

    Sub Main()
        Dim client As New ServiceProxies.AdvCalculatorClient()
        Dim msmqClient As New ServiceProxies.AdvOneWayCalculatorClient()

        Try
            Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Add"}))
            Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Subtract"}))
            Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Multiply"}))
            Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Divide"}))
            Console.WriteLine(client.Process(New MathRequest() With {.Number1 = 100, .Number2 = 200, .Operation = "Power"}))

            'Dim request As New MathRequest() With {.Number1 = 100, .Number2 = 200}
            'Dim result As List(Of MathResult) = client.ProcessAll(request)
            'For Each r In result
            '    Console.WriteLine(r)
            'Next

            'Using MSMQ
            'Console.ReadLine()
            'For index = 1 To 10
            '    msmqClient.ProcessOneWay(New MathRequest() With {.Number1 = 100 + index, .Number2 = 200, .Operation = "Add"})
            '    msmqClient.ProcessOneWay(New MathRequest() With {.Number1 = 100 + index, .Number2 = 200, .Operation = "Subtract"})
            '    msmqClient.ProcessOneWay(New MathRequest() With {.Number1 = 100 + index, .Number2 = 200, .Operation = "Multiply"})
            '    msmqClient.ProcessOneWay(New MathRequest() With {.Number1 = 100 + index, .Number2 = 200, .Operation = "Divide"})
            'Next

            


        Catch fex As FaultException(Of OperationFailureDetail)
            Console.WriteLine(fex.Detail)
        Catch fe As FaultException
            Console.WriteLine(fe)
        Catch ex As Exception
            Console.WriteLine(ex)
        Finally
            Console.WriteLine("Done")
            Console.ReadLine()
        End Try

    End Sub

End Module

Namespace ServiceProxies
    Partial Public Class MathResult
        Public Overrides Function ToString() As String

            Return String.Format("Number1 = {0}, Number2 = {1}, Operation = {2}, Result={3}", Me.Number1, Me.Number2, Me.Operation, Me.Result)
        End Function
    End Class

    Partial Public Class OperationFailureDetail
        Public Overrides Function ToString() As String
            Return String.Format("Error!!  Details : Number1={0}, Number2={1}, Operation={2}, Message={3}", Number1, Number2, Operation, ErrorMessage)
        End Function
    End Class
End Namespace

