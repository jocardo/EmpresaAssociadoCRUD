Imports System.Web.Optimization
Imports System.Web.Security
Imports System.Web.SessionState
Imports System.Data.Entity

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ' Configurar migrações automáticas
        Database.SetInitializer(New MigrateDatabaseToLatestVersion(Of SeuDbContext, Configuration)())


    End Sub
End Class
