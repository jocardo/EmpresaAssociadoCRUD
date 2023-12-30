Imports System.Web.Mvc

Namespace Controllers
    Public Class SharedController
        Inherits Controller

        Private db As New SeuDbContext()

        ' GET: Shared
        Function Index() As ActionResult
            Return View()
        End Function

        Function ListarAssociados() As ActionResult
            ' Lógica para obter a lista de todas as empresas associadas
            Dim empresasAssociadas = db.AssociadoEmpresa.Include("Empresa").ToList()

            Return View(empresasAssociadas)
        End Function

        Function EditEmpresa(id As Integer, associadoEmpresa As AssociadoEmpresaModel) As ActionResult
            Return RedirectToAction("Associar", "Empresa", New With {.id = id})
        End Function

        Function EditAssociado(id As Integer, associadoEmpresa As AssociadoEmpresaModel) As ActionResult
            Return RedirectToAction("Associar", "Associado", New With {.id = id})
        End Function


        Function Delete(idEmpresa As Integer, idAssociado As Integer) As ActionResult
            Dim associadoEmpresa = db.AssociadoEmpresa.Find(idEmpresa, idAssociado)
            If associadoEmpresa IsNot Nothing Then
                ' Lógica para remover associados do relacionamento
                ' ...

                ' Remover empresa do banco de dados
                db.AssociadoEmpresa.Remove(associadoEmpresa)
                db.SaveChanges()
                Return RedirectToAction("ListarAssociados")
            Else
                Return HttpNotFound()
            End If
        End Function

    End Class
End Namespace