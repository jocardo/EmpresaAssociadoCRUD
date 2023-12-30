Imports System.Data.Entity.Migrations

Public Class Configuration
    Inherits DbMigrationsConfiguration(Of SeuDbContext)

    Public Sub New()
        AutomaticMigrationsEnabled = True
    End Sub
End Class
