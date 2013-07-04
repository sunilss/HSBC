Imports System.ServiceModel
Imports System.ServiceModel.Description


Imports HSBCServicesApp.Contracts

Module Module1

    Sub Main()
        Dim number1 As Integer = 10, number2 As Integer = 20
        Dim channel = ChannelFactory(Of ICalculator).CreateChannel(New BasicHttpBinding(), New EndpointAddress("http://localhost:9090/HSBCServices/CalculatorService"))
        Console.WriteLine("Adding {0} and {1} results in {2}", number1, number2, channel.Add(number1, number2))
        Console.WriteLine("Subtracting {0} from {1} results in {2}", number1, number2, channel.Subtract(number1, number2))
        Console.WriteLine("Multiplying {0} and {1} results in {2}", number1, number2, channel.Multiply(number1, number2))
        Console.WriteLine("Dividing {0} by {1} results in {2}", number1, number2, channel.Divide(number1, number2))
        Console.ReadLine()
    End Sub

End Module
