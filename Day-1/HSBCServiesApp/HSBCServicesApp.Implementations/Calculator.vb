Imports System.ServiceModel
Imports HSBCServicesApp.Contracts
Imports System.Threading

<ServiceBehavior()>
Public Class Calculator
    Implements ICalculator
    Implements IAdvCalculator


    <OperationBehavior()>
    Public Function Add(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer Implements Contracts.ICalculator.Add
        'Thread.Sleep(15000)
        Return Number1 + Number2

    End Function

    <OperationBehavior()>
    Public Function Divide(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer Implements Contracts.ICalculator.Divide
        Return Number1 / Number2
    End Function

    <OperationBehavior()>
    Public Function Multiply(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer Implements Contracts.ICalculator.Multiply
        Return Number1 * Number2
    End Function

    <OperationBehavior()>
    Public Function Subtract(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer Implements Contracts.ICalculator.Subtract
        Return Number1 - Number2
    End Function

    <OperationBehavior()>
    Public Function Process(ByVal request As Contracts.MathRequest) As Contracts.MathResult Implements Contracts.IAdvCalculator.Process
        Dim result As Integer
        Select Case request.Operation
            Case "Add"
                result = Add(request.Number1, request.Number2)

            Case "Subtract"
                result = Subtract(request.Number1, request.Number2)
            Case "Multiply"
                result = Multiply(request.Number1, request.Number2)
            Case "Divide"
                result = Divide(request.Number1, request.Number2)


        End Select
        Return New MathResult With {.Number1 = request.Number1, .Number2 = request.Number2, .Operation = request.Operation, .Result = result}
    End Function

    <OperationBehavior()>
    Public Function ProcessAll(ByVal request As Contracts.MathRequest) As List(Of Contracts.MathResult) Implements Contracts.IAdvCalculator.ProcessAll
        Dim result As New List(Of MathResult)

        result.Add(New MathResult With {.Number1 = request.Number1, .Number2 = request.Number2, .Operation = request.Operation, .Result = Add(request.Number1, request.Number2)})
        result.Add(New MathResult With {.Number1 = request.Number1, .Number2 = request.Number2, .Operation = request.Operation, .Result = Subtract(request.Number1, request.Number2)})
        result.Add(New MathResult With {.Number1 = request.Number1, .Number2 = request.Number2, .Operation = request.Operation, .Result = Multiply(request.Number1, request.Number2)})
        result.Add(New MathResult With {.Number1 = request.Number1, .Number2 = request.Number2, .Operation = request.Operation, .Result = Divide(request.Number1, request.Number2)})
        Return result
    End Function
End Class
