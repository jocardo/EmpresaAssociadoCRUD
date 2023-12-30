Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class EmpresaModel
    Public Property Id As Integer
    <Required(ErrorMessage:="O campo Nome é obrigatório.")>
    Public Property Nome As String

    <Required(ErrorMessage:="O campo CNPJ é obrigatório.")>
    <RegularExpression("^\d{14}$", ErrorMessage:="CNPJ inválido.")>
    Public Property Cnpj As String

    ' Relacionamento muitos para muitos com AssociadoModel
    Public Overridable Property Associados As ICollection(Of AssociadoModel) = New List(Of AssociadoModel)

    Public Property AssociadosAssociados As ICollection(Of AssociadoEmpresaModel)
    ' Outras propriedades e métodos conforme necessário

    ' Exemplo de método para validação
    Public Function Validar() As List(Of String)
        Dim erros As New List(Of String)

        ' Lógica de validação customizada, se necessário

        Return erros
    End Function
End Class
