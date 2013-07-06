Imports System.ServiceModel

Public Class Form1
    Implements ServiceProxies.IChatServiceCallback

    Dim client As New ServiceProxies.ChatServiceClient(New InstanceContext(Me))

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub ReceiveMessage(ByVal Message As String) Implements ServiceProxies.IChatServiceCallback.ReceiveMessage
        lstMessages.Items.Add(Message)
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        client.Login(txtName.Text)

    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        client.PostMessage(txtMessage.Text)
    End Sub
End Class
