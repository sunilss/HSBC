Imports System.Web
Imports System.Linq
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity

Namespace TaskManagerApp
    Public Class TodosController
        Inherits System.Web.Mvc.Controller


        Dim dbContext As MVCAppContext
        Dim todosObject As DbSet(Of Todo) = dbContext.Todos
        Public Sub New(context As MVCAppContext)
            dbContext = context

        End Sub
        '
        ' GET: /Todos

        Function Validate(IsCompleted As Boolean) As ActionResult
            If (IsCompleted) Then
                Return Json(False, JsonRequestBehavior.AllowGet)
            End If
            Return Json(True, JsonRequestBehavior.AllowGet)
            'Return ValidationResult.Success
        End Function

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
            Dim vm As New TodosViewModel With {.NewTodo = New Todo(), .Todos = result}
            Return View(vm)
        End Function

        <HttpGet()>
        Function Add() As ActionResult
            Return View(New Todo)
        End Function

        <HttpPost()>
        Function Add(newTodo As Todo) As ActionResult
            If (ModelState.IsValid) Then

                todosObject.Add(newTodo)
                If (Request.IsAjaxRequest) Then
                    Return RedirectToAction("List")
                End If
                Return RedirectToAction("Index")
            Else
                If (Request.IsAjaxRequest) Then
                    Return PartialView(newTodo)
                Else
                    Return View(newTodo)
                End If
            End If

        End Function

        Function List() As ActionResult
            Return PartialView("List", todosObject)
        End Function

        Function Remove(ByVal id As Integer) As ActionResult
            Dim todoToRemove = todosObject.Find(id)
            todosObject.Remove(todoToRemove)
            Return RedirectToAction("Index")
        End Function

        Function Complete(ByVal id As Integer) As ActionResult
            Dim todo = todosObject.Find(id)
            If (todo IsNot Nothing) Then
                todo.Complete()
            End If
            If (Request.IsAjaxRequest) Then
                'Return PartialView("List", todosObject)
                Return RedirectToAction("List")
            End If
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub OnActionExecuted(filterContext As System.Web.Mvc.ActionExecutedContext)
            dbContext.SaveChanges()

        End Sub


    End Class
End Namespace
