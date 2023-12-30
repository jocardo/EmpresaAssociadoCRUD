Imports System.Web.Mvc
Imports System.Collections.Generic


Public Class EmpresaController
    Inherits Controller

    Private db As New SeuDbContext()

    Function Index() As ActionResult
        Return List()
    End Function

    ' Ação para exibir a página de inclusão de empresas
    Public Function Create() As ActionResult
        Return View()
    End Function

    ' Ação para processar a inclusão de empresas
    <HttpPost>
    Public Function Create(model As EmpresaModel) As ActionResult
        If ModelState.IsValid Then
            ' Lógica para validar CNPJ único
            If Not db.Empresas.Any(Function(e) e.Cnpj = model.Cnpj) Then
                ' Adicionar empresa ao banco de dados
                db.Empresas.Add(model)
                db.SaveChanges()
                Return RedirectToAction("Index")
            Else
                ModelState.AddModelError("Cnpj", "CNPJ já cadastrado.")
            End If
        End If
        Return View(model)
    End Function

    ' Ação para exibir a página de alteração de empresas
    Public Function Edit(id As Integer) As ActionResult
        Dim empresa = db.Empresas.Find(id)
        If empresa IsNot Nothing Then
            Return View(empresa)
        Else
            Return HttpNotFound()
        End If
    End Function

    Public Function Details(id As Integer) As ActionResult
        Dim empresa = db.Empresas.Find(id)
        If empresa IsNot Nothing Then
            Return View(empresa)
        Else
            Return HttpNotFound()
        End If
    End Function

    ' Ação para processar a alteração de empresas
    <HttpPost>
    Public Function Edit(model As EmpresaModel) As ActionResult
        If ModelState.IsValid Then
            Dim empresa = db.Empresas.Find(model.Id)
            If empresa IsNot Nothing Then
                ' Atualizar os dados da empresa
                empresa.Nome = model.Nome
                empresa.Cnpj = model.Cnpj

                ' Lógica para adicionar ou remover associados no relacionamento
                ' ...

                db.SaveChanges()
                Return RedirectToAction("Index")
            Else
                Return HttpNotFound()
            End If
        End If
        Return View(model)
    End Function

    ' Ação para exibir a lista de empresas
    Public Function List() As ActionResult
        Dim empresas = IIf(db.Empresas IsNot Nothing, db.Empresas.ToList(), Nothing)
        Return View(empresas)
    End Function

    ' Ação para exibir a página de exclusão de empresas
    Public Function Delete(id As Integer) As ActionResult
        Dim empresa = db.Empresas.Find(id)
        If empresa IsNot Nothing Then
            Return View(empresa)
        Else
            Return HttpNotFound()
        End If
    End Function

    ' Ação para processar a exclusão de empresas
    <HttpPost>
    Public Function Delete(id As Integer, ByVal EmpresaExcluir As EmpresaModel) As ActionResult
        Dim empresa = db.Empresas.Find(id)
        If empresa IsNot Nothing Then
            ' Lógica para remover associados do relacionamento
            Dim associacoesParaRemover = db.AssociadoEmpresa.Where(Function(ae) ae.EmpresaId = id)
            db.AssociadoEmpresa.RemoveRange(associacoesParaRemover)

            ' Remover empresa do banco de dados
            db.Empresas.Remove(empresa)
            db.SaveChanges()
            Return RedirectToAction("Index")
        Else
            Return HttpNotFound()
        End If
    End Function

    Function Associar(Optional id As Integer = 0) As ActionResult
        ' Exemplo no controlador
        If id = 0 Then
            ViewBag.Empresas = New SelectList(db.Empresas, "Id", "Nome")
            ViewBag.Associados = New MultiSelectList(db.Associados, "Id", "Nome")
        Else
            ' Carregue a empresa específica
            Dim empresa = db.Empresas.Find(id)

            ' Se a empresa existir, carregue os associados associados a ela
            If empresa IsNot Nothing Then
                ViewBag.Empresas = New SelectList(db.Empresas, "Id", "Nome", selectedValue:=id)
                Dim associadosDaEmpresa = db.AssociadoEmpresa.
                                            Where(Function(ae) ae.EmpresaId = id).
                                            Select(Function(ae) ae.AssociadoId).
                                            ToList()
                ViewBag.Associados = New MultiSelectList(db.Associados, "Id", "Nome", associadosDaEmpresa)
            Else
                ' Se a empresa não existir, recarregue todas as empresas e associados
                ViewBag.Empresas = New SelectList(db.Empresas, "Id", "Nome")
                ViewBag.Associados = New MultiSelectList(db.Associados, "Id", "Nome")
            End If
        End If

        Return View()
    End Function


    <HttpPost>
    Function Associar(model As AssociadoEmpresaModel) As ActionResult
        If ModelState.IsValid Then
            ' Remover associações existentes para a empresa
            Dim associacoesParaRemover = db.AssociadoEmpresa.Where(Function(ae) ae.EmpresaId = model.EmpresaId)
            db.AssociadoEmpresa.RemoveRange(associacoesParaRemover)

            ' Lógica para associar os associados à empresa
            ' Iterar sobre os IDs dos associados e criar instâncias de Associacoes
            For Each associadoId In model.AssociadoIds
                Dim associacao As New AssociadoEmpresaModel()
                associacao.EmpresaId = model.EmpresaId
                associacao.AssociadoId = associadoId

                ' Adicione a associação ao contexto e salve as mudanças
                db.AssociadoEmpresa.Add(associacao)
            Next
            db.SaveChanges()

            Return RedirectToAction("ListarAssociados", "Shared") ' ou redirecione para outra ação conforme necessário
        End If

        ' Se houver erros de validação, recarregue as listas e exiba a View novamente
        ViewBag.Empresas = New SelectList(db.Empresas, "Id", "Nome")
        ViewBag.Associados = New MultiSelectList(db.Associados, "Id", "Nome")

        Return View(model)
    End Function



End Class
