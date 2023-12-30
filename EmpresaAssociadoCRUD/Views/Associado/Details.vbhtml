@ModelType EmpresaAssociadoCRUD.AssociadoModel
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>AssociadoModel</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nome)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nome)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cpf)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cpf)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DataNascimento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataNascimento)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
