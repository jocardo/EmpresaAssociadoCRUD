' <auto-generated />
Imports System.CodeDom.Compiler
Imports System.Data.Entity.Migrations
Imports System.Data.Entity.Migrations.Infrastructure
Imports System.Resources

<GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")>
Public NotInheritable Partial Class NovaMigracao
    Implements IMigrationMetadata

    Private ReadOnly Resources As New ResourceManager(GetType(NovaMigracao))
    
    Private ReadOnly Property IMigrationMetadata_Id() As String Implements IMigrationMetadata.Id
        Get
            Return "202312300355466_NovaMigracao"
        End Get
    End Property
    
    Private ReadOnly Property IMigrationMetadata_Source() As String Implements IMigrationMetadata.Source
        Get
            Return Nothing
        End Get
    End Property
    
    Private ReadOnly Property IMigrationMetadata_Target() As String Implements IMigrationMetadata.Target
        Get
            Return Resources.GetString("Target")
        End Get
    End Property
End Class
