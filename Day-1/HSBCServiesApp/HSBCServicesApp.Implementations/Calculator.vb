Imports System.ServiceModel
Imports HSBCServicesApp.Contracts

<ServiceBehavior()>
Public Class Calculator
    Implements ICalculator

    <OperationBehavior()>
    Public Function Add(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer Implements Contracts.ICalculator.Add
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
End Class
