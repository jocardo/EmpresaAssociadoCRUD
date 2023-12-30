Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Public Partial Class NovaMigracao
    Inherits DbMigration

    Public Overrides Sub Up()
        ' DropPrimaryKey("dbo.AssociadoEmpresaModels")
        ' AddPrimaryKey("dbo.AssociadoEmpresaModels", New String() { "AssociadoId", "EmpresaId" })
        ' DropColumn("dbo.AssociadoEmpresaModels", "Id")
    End Sub
    
    Public Overrides Sub Down()
        ' AddColumn("dbo.AssociadoEmpresaModels", "Id", Function(c) c.Int(nullable := False, identity := True))
        ' DropPrimaryKey("dbo.AssociadoEmpresaModels")
        AddPrimaryKey("dbo.AssociadoEmpresaModels", New String() {"AssociadoId", "EmpresaId"})
    End Sub
End Class
