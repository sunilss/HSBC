Imports System.ServiceModel
Imports System.ServiceModel.Description

Imports HSBCServicesApp.Implementations
Imports HSBCServicesApp.Contracts

Module Module1

    Sub Main()
        Dim host As New ServiceHost(GetType(Calculator))

        host.AddServiceEndpoint(GetType(ICalculator), _
                                New BasicHttpBinding(), _
                                "http://localhost:9090/HSBCServices/CalculatorService")

        For Each endpoint In host.Description.Endpoints
            Console.WriteLine("{0},{1},{2}", endpoint.Address, endpoint.Binding, endpoint.Contract.Name)
        Next
        host.Open()
        Console.WriteLine("Service host running... press ENTER to shutdown")
        Console.ReadLine()
        host.Close()
    End Sub

End Module
