Imports System.ServiceModel
Imports HSBCServicesApp.Implementations

Public Class CalculatorService
    Dim host As ServiceHost
    Protected Overrides Sub OnStart(ByVal args() As String)
        host = New ServiceHost(GetType(Calculator))
        host.Open()
    End Sub

    Protected Overrides Sub OnStop()
        host.Close()
    End Sub

End Class
