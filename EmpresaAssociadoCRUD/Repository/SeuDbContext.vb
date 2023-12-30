Imports System.Data.Entity

Public Class SeuDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("Data Source=10.221.121.240; Initial Catalog=SGRRM_HOMOLOGACAO; uid=sa; pwd=#BJ_live2021; language=portuguese; MultipleActiveResultSets=True") ' Substitua pelo nome real da sua string de conexão
    End Sub

    Public Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub

    ' Defina os DbSet para Associado e Empresa aqui
    Public Property Associados As DbSet(Of AssociadoModel)
    Public Property Empresas As DbSet(Of EmpresaModel)

    ' Defina o DbSet para a tabela de relacionamento
    Public Property AssociadoEmpresa As DbSet(Of AssociadoEmpresaModel)


    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        ' Configurar a chave primária composta na tabela de relacionamento
        modelBuilder.Entity(Of AssociadoEmpresaModel)() _
            .HasKey(Function(ae) New With {ae.AssociadoId, ae.EmpresaId})

        ' Configurar as chaves estrangeiras
        modelBuilder.Entity(Of AssociadoEmpresaModel)() _
            .HasRequired(Function(ae) ae.Associado) _
            .WithMany(Function(a) a.EmpresasAssociadas) _
            .HasForeignKey(Function(ae) ae.AssociadoId)

        modelBuilder.Entity(Of AssociadoEmpresaModel)() _
            .HasRequired(Function(ae) ae.Empresa) _
            .WithMany(Function(e) e.AssociadosAssociados) _
            .HasForeignKey(Function(ae) ae.EmpresaId)

        MyBase.OnModelCreating(modelBuilder)
    End Sub

End Class
