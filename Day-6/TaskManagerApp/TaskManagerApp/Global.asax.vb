Imports System.Data.Entity

' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Todos", .action = "Index", .id = UrlParameter.Optional} _
        )

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        Database.SetInitializer(Of MVCAppContext)(New DropCreateDatabaseIfModelChanges(Of MVCAppContext)())
        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)
        ControllerBuilder.Current.SetControllerFactory(New MyCustomControllerFactory())
    End Sub
End Class

Public Class MyCustomControllerFactory
    Implements IControllerFactory

    Public Function CreateController(requestContext As System.Web.Routing.RequestContext, controllerName As String) As System.Web.Mvc.IController Implements System.Web.Mvc.IControllerFactory.CreateController
        If (requestContext.RouteData.Values("controller") = "Todos") Then
            Return New TaskManagerApp.TodosController(New MVCAppContext())

        End If
    End Function

    Public Function GetControllerSessionBehavior(requestContext As System.Web.Routing.RequestContext, controllerName As String) As System.Web.SessionState.SessionStateBehavior Implements System.Web.Mvc.IControllerFactory.GetControllerSessionBehavior

    End Function

    Public Sub ReleaseController(controller As System.Web.Mvc.IController) Implements System.Web.Mvc.IControllerFactory.ReleaseController

    End Sub
End Class
