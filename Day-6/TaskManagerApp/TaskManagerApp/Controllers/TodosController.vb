Imports System.Web

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

        Function Index() As ActionResult
            Return View(todosObject)
        End Function

        Function Add() As ActionResult
            Return View(New Todo)
        End Function

        Function AddNew(todo As Todo) As ActionResult
            todosObject.Add(todo.Name)
            Me.Session("todos") = todosObject
            Return View("Index", todosObject)
        End Function
    End Class
End Namespace
