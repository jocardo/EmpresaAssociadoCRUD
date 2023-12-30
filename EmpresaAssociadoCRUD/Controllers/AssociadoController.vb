Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class AssociadoController
        Inherits Controller

        Private db As New SeuDbContext() ' Substitua SeuDbContext pelo seu contexto do banco de dados

        ' GET: AssociadoController
        Function Index() As ActionResult
            Dim listaDeAssociados As IEnumerable(Of AssociadoModel) = ObterDadosDoBancoDeDados()
            Return View(listaDeAssociados)
        End Function

        ' GET: AssociadoController/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Dim listaDeAssociados As IEnumerable(Of AssociadoModel) = ObterDadosDoBancoDeDados(id)
            Dim associado As AssociadoModel = listaDeAssociados.FirstOrDefault(Function(a) a.Id = id)

            Return View(associado)
        End Function

        ' Ação para exibir a página de inclusão de empresas
        Public Function Create() As ActionResult
            Return View()
        End Function

        ' Ação para processar a inclusão de empresas
        <HttpPost>
        Function Create(model As AssociadoModel) As ActionResult
            If ModelState.IsValid Then
                ' Lógica para validar CNPJ único
                If Not db.Associados.Any(Function(e) e.Cpf = model.Cpf) Then
                    ' Adicionar empresa ao banco de dados
                    db.Associados.Add(model)
                    db.SaveChanges()
                    Return RedirectToAction("Index")
                Else
                    ModelState.AddModelError("Cpf", "CPF já cadastrado.")
                End If
            End If
            Return View(model)
        End Function


        Function Incluir() As ActionResult
            Return View()
        End Function
        Function Listar() As ActionResult
            Dim listaDeAssociados As IEnumerable(Of AssociadoModel) = ObterDadosDoBancoDeDados()
            Return View(listaDeAssociados)
        End Function

        ' Ação para processar a inclusão de empresas
        <HttpPost>
        Public Function Incluir(model As AssociadoModel) As ActionResult
            If ModelState.IsValid Then
                ' Lógica para validar CNPJ único
                If Not db.Associados.Any(Function(e) e.Cpf = model.Cpf) Then
                    ' Adicionar empresa ao banco de dados
                    db.Associados.Add(model)
                    db.SaveChanges()
                    Return RedirectToAction("Listar")
                Else
                    ModelState.AddModelError("Cnpj", "CNPJ já cadastrado.")
                End If
            End If
            Return View(model)
        End Function

        ' GET: AssociadoController/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Dim listaDeAssociados As IEnumerable(Of AssociadoModel) = ObterDadosDoBancoDeDados(id)
            Dim associado As AssociadoModel = listaDeAssociados.FirstOrDefault(Function(a) a.Id = id)

            Return View(associado)
        End Function

        ' POST: AssociadoController/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal associadoAtualizado As AssociadoModel) As ActionResult
            Try
                Using db
                    ' Recupera o associado pelo ID
                    Dim associadoExistente As AssociadoModel = db.Associados.FirstOrDefault(Function(a) a.Id = id)

                    ' Verifica se o associado foi encontrado
                    If associadoExistente IsNot Nothing Then
                        ' Atualiza as propriedades do associado com os novos valores
                        associadoExistente.Nome = associadoAtualizado.Nome
                        associadoExistente.Cpf = associadoAtualizado.Cpf
                        associadoExistente.DataNascimento = associadoAtualizado.DataNascimento

                        ' Salva as mudanças no banco de dados
                        db.SaveChanges()

                        ' Redireciona para a página de detalhes após a edição
                        Return RedirectToAction("Details", New With {.id = id})
                    End If
                End Using

            Catch ex As Exception
                ' Loga a exceção ou realiza alguma ação apropriada
                Console.WriteLine("Erro ao atualizar associado: " & ex.Message)
                Return View()
            End Try
        End Function

        ' GET: AssociadoController/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Dim listaDeAssociados As IEnumerable(Of AssociadoModel) = ObterDadosDoBancoDeDados(id)
            Dim associado As AssociadoModel = listaDeAssociados.FirstOrDefault(Function(a) a.Id = id)

            Return View(associado)
        End Function

        ' POST: AssociadoController/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                Using db
                    Dim associado = db.Associados.Find(id)
                    If associado IsNot Nothing Then

                        ' Lógica para remover associados do relacionamento
                        Dim associacoesParaRemover = db.AssociadoEmpresa.Where(Function(ae) ae.AssociadoId = id)
                        db.AssociadoEmpresa.RemoveRange(associacoesParaRemover)

                        db.Associados.Remove(associado)
                        db.SaveChanges()
                    End If
                End Using

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        Function ObterDadosDoBancoDeDados(Optional ByVal id As Integer = 0) As IEnumerable(Of AssociadoModel)
            Using db

                ' Aqui você substituiria por uma consulta real ao banco de dados
                ' Esta é apenas uma consulta fictícia para ilustração
                Dim listaDeAssociados = db.Associados.ToList()

                If id = 0 Then

                    ' Convertemos os objetos do banco de dados (entidades) para os objetos do modelo
                    Dim listaDeAssociadosModel = listaDeAssociados.Select(Function(a) New AssociadoModel() With {
                    .Id = a.Id,
                    .Nome = a.Nome,
                    .Cpf = a.Cpf,
                    .DataNascimento = a.DataNascimento
                }).ToList()

                    Return listaDeAssociadosModel
                Else
                    ' Aqui você substituiria por uma consulta real ao banco de dados
                    ' Esta é apenas uma consulta fictícia para ilustração
                    Dim associado = db.Associados.FirstOrDefault(Function(a) a.Id = id)

                    ' Verificamos se o associado foi encontrado
                    If associado IsNot Nothing Then
                        ' Convertemos o objeto do banco de dados (entidade) para o objeto do modelo
                        Dim associadoModel As New AssociadoModel() With {
                            .Id = associado.Id,
                            .Nome = associado.Nome,
                            .Cpf = associado.Cpf,
                            .DataNascimento = associado.DataNascimento
                        }
                        Dim list = New List(Of AssociadoModel)
                        list.Add(associadoModel)
                        listaDeAssociados = list

                        Return listaDeAssociados
                    Else
                        ' Se o associado não for encontrado, você pode tomar alguma ação, como lançar uma exceção ou retornar Nothing
                        Return Nothing
                    End If
                End If
            End Using
        End Function


        Function Associar(Optional id As Integer = 0) As ActionResult
            ' Exemplo no controlador
            If id = 0 Then
                ViewBag.Associados = New SelectList(db.Associados, "Id", "Nome")
                ViewBag.Empresas = New MultiSelectList(db.Empresas, "Id", "Nome")
            Else
                Dim associado = db.Associados.Find(id)

                If associado IsNot Nothing Then
                    ViewBag.Associados = New SelectList(db.Associados, "Id", "Nome", selectedValue:=id)
                    Dim associadosDaEmpresa = db.AssociadoEmpresa.
                                                Where(Function(ae) ae.AssociadoId = id).
                                                Select(Function(ae) ae.EmpresaId).
                                                ToList()
                    ViewBag.Empresas = New MultiSelectList(db.Empresas, "Id", "Nome", associadosDaEmpresa)
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
                For Each empresaId In model.EmpresaIds
                    Dim associacao As New AssociadoEmpresaModel()
                    associacao.EmpresaId = empresaId
                    associacao.AssociadoId = model.AssociadoId

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
End Namespace