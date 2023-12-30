Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )
        routes.MapRoute(
            name:="Associado",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Associado", .action = "Index", .id = UrlParameter.Optional}
        )
        routes.MapRoute(
            name:="Empresa",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Empresa", .action = "Index", .id = UrlParameter.Optional}
        )
        routes.MapRoute(
            name:="Shared",
            url:="{controller}/{action}",
            defaults:=New With {.controller = "Empresa", .action = "Index"}
        )


    End Sub
End Module