Imports System.ServiceModel

<ServiceContract()>
Public Interface IAdvCalculator
    <OperationContract()>
    Function Process(ByVal request As MathRequest) As MathResult

    <OperationContract()>
    Function ProcessAll(ByVal request As MathRequest) As List(Of MathResult)
End Interface
