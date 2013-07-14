Imports WCFSecurityDemoClient.ServiceReference1
Imports System.Net
Imports System.Security.Cryptography.X509Certificates

Module Module1

    Sub Main()
        'Console.WriteLine(Guid.NewGuid)
        PermissiveCertificatePolicy.Enact("CN=HTTPS-Server")
        Dim client As New CalculatorClient("BasicHttpBinding_ICalculator")
        client.ClientCredentials.UserName.UserName = "AlterEgo\tkmagesh"
        client.ClientCredentials.UserName.Password = "arunachala"
        'Dim client As New CalculatorClient("WSHttpBinding_ICalculator")
        Console.WriteLine(client.Add(100, 200))
        Console.ReadLine()
    End Sub

End Module

Public Class PermissiveCertificatePolicy
    Private subjectName As String
    Private Shared CurrentPolicy As PermissiveCertificatePolicy

    Public Sub New(subjectName As String)
        Me.subjectName = subjectName
        'AddHandler ServicePointManager.ServerCertificateValidationCallback, AddressOf RemoteCertValidate
        ServicePointManager.ServerCertificateValidationCallback = AddressOf RemoteCertValidate
    End Sub

    Public Shared Sub Enact(subjectName As String)
        CurrentPolicy = New PermissiveCertificatePolicy(subjectName)
    End Sub

    Public Function RemoteCertValidate(sender As Object, cert As X509Certificate, chain As X509Chain, errors As System.Net.Security.SslPolicyErrors) As Boolean
        Return cert.Subject = subjectName
    End Function
End Class
