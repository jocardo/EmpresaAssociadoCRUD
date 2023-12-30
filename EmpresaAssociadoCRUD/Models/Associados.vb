Imports System.ComponentModel.DataAnnotations

Public Class AssociadoModel
    Public Property Id As Integer
    <Required(ErrorMessage:="O campo Nome é obrigatório.")>
    Public Property Nome As String

    <Required(ErrorMessage:="O campo CPF é obrigatório.")>
    <RegularExpression("^\d{11}$", ErrorMessage:="CPF inválido.")>
    Public Property Cpf As String

    Public Property DataNascimento As DateTime

    ' Relacionamento muitos para muitos com EmpresaModel
    Public Overridable Property Empresas As ICollection(Of EmpresaModel) = New List(Of EmpresaModel)

    Public Property EmpresasAssociadas As ICollection(Of AssociadoEmpresaModel)
    ' Exemplo de método para validação
    Public Function Validar() As List(Of String)
        Dim erros As New List(Of String)

        ' Lógica de validação customizada, se necessário
        If DataNascimento > DateTime.Now Then
            erros.Add("A data de nascimento não pode ser no futuro.")
        End If

        Return erros
    End Function
End Class
