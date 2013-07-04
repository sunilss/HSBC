Module Module1
    Dim WithEvents client As New ServiceProxies.CalculatorClient("NetTcpBinding_ICalculator")
    Sub Main()




        ''Console.WriteLine(client.Add(100, 200))

        client.AddAsync(100, 200)
        Console.WriteLine("Add call initiated")
        'Console.WriteLine(client.Subtract(100, 200))
        'Console.WriteLine(client.Multiply(100, 200))
        'Console.WriteLine(client.Divide(100, 200))
        Console.ReadLine()
    End Sub

    Public Sub OnAddCompleted(ByVal sender As Object, ByVal e As CalculatorClientUsingProxy.ServiceProxies.AddCompletedEventArgs) Handles client.AddCompleted
        Console.WriteLine("Add result = " + e.Result.ToString())

    End Sub

End Module
