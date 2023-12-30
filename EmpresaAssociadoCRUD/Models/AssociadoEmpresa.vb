Imports System.ComponentModel.DataAnnotations

Public Class AssociadoEmpresaModel
    <Key>
    Public Property AssociadoId As Integer
    <Key>
    Public Property EmpresaId As Integer


    Public Property AssociadoIds As List(Of Integer)
    Public Property EmpresaIds As List(Of Integer)

    ' Adicione estas propriedades de navegação
    Public Overridable Property Associado As AssociadoModel
    Public Overridable Property Empresa As EmpresaModel
End Class
