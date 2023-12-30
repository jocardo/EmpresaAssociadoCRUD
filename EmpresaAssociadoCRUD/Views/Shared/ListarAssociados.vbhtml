@ModelType List(Of AssociadoEmpresaModel)

<h2>Empresas Associadas</h2>

@If Model IsNot Nothing AndAlso Model.Any() Then
    @<Table Class="table">
        <thead>
            <tr>
                <th> Id Empresa</th>
                <th> Nome Empresa</th>
                <th />
                <th> Id Associado</th>
                <th> Associados</th>
            </tr>
        </thead>
        <tbody>
            @For Each associadoEmpresa In Model
                @<tr>
    <td>@associadoEmpresa.Empresa.Id</td>
    <td>@associadoEmpresa.Empresa.Nome</td>
    <td>
        @Html.ActionLink("Edit", "EditEmpresa", New With {.id = associadoEmpresa.Empresa.Id}) 
    </td>
    <td>
        @If associadoEmpresa.Associado IsNot Nothing Then
            @associadoEmpresa.Associado.Id @*- @associadoEmpresa.Associado.Cpf*@
        Else
            @<span>Sem Associados</span>
        End If
    </td>
    <td>
        @If associadoEmpresa.Associado IsNot Nothing Then
            @associadoEmpresa.Associado.Nome @*- @associadoEmpresa.Associado.Cpf*@
        Else
            @<span>Sem Associados</span>
        End If
    </td>
    <td>
        @Html.ActionLink("Edit", "EditAssociado", New With {.id = associadoEmpresa.Associado.Id}) 
    </td>
    <td>
        @Html.ActionLink("Delete", "Delete", New With {.idEmpresa = associadoEmpresa.Empresa.Id, .idAssociado = associadoEmpresa.Associado.Id})
    </td>
</tr>
            Next
        </tbody>
    </Table>
Else
@<p> Nenhuma empresa associada encontrada.</p>
End If
