Imports System.Web
Imports System.Linq

Namespace TaskManagerApp
    Public Class TodosController
        Inherits System.Web.Mvc.Controller

        Dim todosObject As New Todos
        Public Sub New()

            If (System.Web.HttpContext.Current.Session("todos") Is Nothing) Then
                todosObject = New Todos()
                System.Web.HttpContext.Current.Session.Add("todos", todosObject)
            Else
                todosObject = CType(System.Web.HttpContext.Current.Session("todos"), Todos)
            End If

        End Sub
        '
        ' GET: /Todos

        Function Index(Optional Filter As String = "All") As ActionResult
            Dim result As IEnumerable(Of Todo)
            Select Case Filter
                Case "All"
                    result = todosObject
                Case "Completed"
                    result = todosObject.Where(Function(t) t.IsCompleted())
                Case "InComplete"
                    result = todosObject.Where(Function(t) Not t.IsCompleted())

            End Select
            Return View(result)
        End Function

        <HttpGet()>
        Function Add() As ActionResult
            Return View(New Todo)
        End Function

        <HttpPost()>
        Function Add(todo As Todo) As ActionResult
            todosObject.Add(todo.Name)
            Return RedirectToAction("Index")
        End Function

        Function Remove(ByVal id As Integer) As ActionResult
            todosObject.Remove(id)
            Return RedirectToAction("Index")
        End Function

        Function Complete(ByVal id As Integer) As ActionResult
            Dim todo = todosObject.GetById(id)
            If (todo IsNot Nothing) Then
                todo.Complete()
            End If
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub OnActionExecuted(filterContext As System.Web.Mvc.ActionExecutedContext)
            Me.Session("todos") = todosObject
            MyBase.OnActionExecuted(filterContext)
        End Sub


    End Class
End Namespace
