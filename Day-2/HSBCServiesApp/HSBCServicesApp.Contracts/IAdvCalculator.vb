Imports System.ServiceModel

<ServiceContract()>
Public Interface IAdvCalculator

    <OperationContract()>
    <FaultContract(GetType(OperationFailureDetail))>
    Function Process(ByVal request As MathRequest) As MathResult

    <OperationContract()>
    <FaultContract(GetType(OperationFailureDetail))>
    Function ProcessAll(ByVal request As MathRequest) As List(Of MathResult)

    
End Interface

<ServiceContract()>
Public Interface IAdvOneWayCalculator

    'Oneway for MSMQ
    <OperationContract(IsOneWay:=True)>
    Sub ProcessOneWay(ByVal request As MathRequest)
End Interface
