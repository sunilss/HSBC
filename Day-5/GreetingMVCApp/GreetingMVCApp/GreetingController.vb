Imports System.IO

Public Class MyControllerBase
    Inherits Controller

    Public Function RenderHTML(ByVal templateName As String, ByVal data As Object) As String
        Dim templatePath = Path.Combine(Server.MapPath("~\HtmlTemplates\" + Me.ControllerContext.RouteData.Values("controller")), templateName + ".txt")
        Dim streamReader = New StreamReader(templatePath)
        Dim outputTemplate = streamReader.ReadToEnd()
        streamReader.Close()
        Return String.Format(outputTemplate, data)
    End Function
End Class

Public Class GreetingController
    Inherits MyControllerBase

    Public Function Greet(ByVal firstName As String, ByVal lastName As String) As String
        Dim responseData = firstName + " " + lastName
        Return RenderHTML("Greet", responseData)
    End Function

    Public Function GetCurrentTime() As String
        Return RenderHTML("GetTime", DateAndTime.Now)
    End Function

    Public Function GreetInput() As String
        Return RenderHTML("GreetInput", Nothing)
    End Function

End Class
