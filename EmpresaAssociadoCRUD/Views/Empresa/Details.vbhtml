@ModelType EmpresaAssociadoCRUD.EmpresaModel
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>EmpresaModel</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nome)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nome)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cnpj)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cnpj)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
