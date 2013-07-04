Public Class Form1
    Dim WithEvents client As New ServiceProxies.CalculatorClient("BasicHttpBinding_ICalculator")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim result As Integer = client.Add(100, 200)
        client.AddAsync(100, 200)
        Me.Label1.Text = "Please wait!"
    End Sub

    Private Sub OnAddCompleted(ByVal Obj As Object, ByVal e As ServiceProxies.AddCompletedEventArgs) Handles client.AddCompleted

        Me.Label1.Text = e.Result.ToString()
    End Sub
End Class
