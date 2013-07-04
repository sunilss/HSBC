Imports System.ServiceModel

<ServiceContract()>
Public Interface ICalculator

    <OperationContract()>
    Function Add(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer

    <OperationContract()>
    Function Subtract(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer

    <OperationContract()>
    Function Multiply(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer

    <OperationContract()>
    Function Divide(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer

End Interface
