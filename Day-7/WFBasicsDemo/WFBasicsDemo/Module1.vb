Imports System.Activities
Imports System.Activities.Statements
Imports System.Diagnostics
Imports System.Linq

Module Module1

    Dim s As Sequence

    Sub Main()
        Dim args As New Dictionary(Of String, Object)
        args.Add("name", "Magesh")
        WorkflowInvoker.Invoke(New Workflow1(), args)

    End Sub

End Module
