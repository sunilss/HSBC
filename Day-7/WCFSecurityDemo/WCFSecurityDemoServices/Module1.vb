Imports System.ServiceModel

Module Module1

    Sub Main()
        Dim host As New ServiceHost(GetType(CalculatorService))
        host.Open()
        Console.WriteLine("ENTER to shutdown")
        Console.ReadLine()
        host.Close()
        Console.WriteLine("Done")
        Console.ReadLine()
    End Sub

End Module

<ServiceContract()>
Public Interface ICalculator
    <OperationContract()>
    Function Add(number1 As Integer, number2 As Integer) As Integer
    <OperationContract()>
    Function Subtract(number1 As Integer, number2 As Integer) As Integer
    <OperationContract()>
    Function Multiply(number1 As Integer, number2 As Integer) As Integer
    <OperationContract()>
    Function Divide(number1 As Integer, number2 As Integer) As Integer
End Interface

<ServiceBehavior()>
Public Class CalculatorService
    Implements ICalculator

    <OperationBehavior()>
    Public Function Add(number1 As Integer, number2 As Integer) As Integer Implements ICalculator.Add
        Return number1 + number2
    End Function

    <OperationBehavior()>
    Public Function Divide(number1 As Integer, number2 As Integer) As Integer Implements ICalculator.Divide
        Return number1 / number2
    End Function

    <OperationBehavior()>
    Public Function Multiply(number1 As Integer, number2 As Integer) As Integer Implements ICalculator.Multiply
        Return number1 * number2
    End Function

    <OperationBehavior()>
    Public Function Subtract(number1 As Integer, number2 As Integer) As Integer Implements ICalculator.Subtract
        Return number1 - number2
    End Function
End Class

