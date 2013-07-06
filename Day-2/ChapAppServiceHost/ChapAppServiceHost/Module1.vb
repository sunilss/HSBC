Imports System.ServiceModel

Module Module1

    Sub Main()
        Dim host As New ServiceHost(GetType(ChatService))
        host.Open()
        For Each ep In host.Description.Endpoints
            Console.WriteLine(ep.Address)
        Next
        Console.WriteLine("Service running... press ENTER to shutdown")
        Console.ReadLine()
        host.Close()

    End Sub

End Module

<ServiceBehavior(InstanceContextMode:=ServiceModel.InstanceContextMode.Single)>
Public Class ChatService
    Implements IChatService

    Dim callbacks As New Dictionary(Of IChatDuplexContract, String)
    <OperationBehavior()>
    Public Sub Login(ByVal Name As String) Implements IChatService.Login
        Dim callback As IChatDuplexContract = _
            OperationContext.Current.GetCallbackChannel(Of IChatDuplexContract)()
        callbacks.Add(callback, Name)
    End Sub

    <OperationBehavior()>
    Public Sub LogOff() Implements IChatService.LogOff
        Dim callback As IChatDuplexContract = OperationContext.Current.GetCallbackChannel(Of IChatDuplexContract)()
        callbacks.Remove(callback)
    End Sub

    <OperationBehavior()>
    Public Sub PostMessage(ByVal Message As String) Implements IChatService.PostMessage
        Dim callback As IChatDuplexContract = OperationContext.Current.GetCallbackChannel(Of IChatDuplexContract)()
        For Each cb In callbacks
            If (cb.Key IsNot callback) Then
                cb.Key.ReceiveMessage(Message)
            End If
        Next
    End Sub
End Class

<ServiceContract()>
Public Interface IChatDuplexContract

    <OperationContract()>
    Sub ReceiveMessage(ByVal Message As String)

End Interface

<ServiceContract(CallbackContract:=GetType(IChatDuplexContract))>
Public Interface IChatService

    <OperationContract()>
    Sub Login(ByVal Name As String)

    <OperationContract()>
    Sub PostMessage(ByVal Message As String)

    <OperationContract()>
    Sub LogOff()

End Interface