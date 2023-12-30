@ModelType EmpresaAssociadoCRUD.AssociadoEmpresaModel
@Code
    ViewData("Title") = "Associar Empresas"
End Code

<h2>Associar Associados à Empresa</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()

    @<div Class="form-group">
        @Html.LabelFor(Function(model) model.AssociadoId, "Selecione os Associados:")
        @Html.DropDownListFor(Function(model) model.AssociadoId, CType(ViewBag.Associados, IEnumerable(Of SelectListItem)), "Selecione um Associado", New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.AssociadoId, "", New With {.class = "text-danger"})
    </div>

    @<div Class="form-group">
        @Html.LabelFor(Function(model) model.EmpresaIds, "Selecione a Empresa:")
        @Html.ListBoxFor(Function(model) model.EmpresaIds, CType(ViewBag.Empresas, IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.EmpresaIds, "", New With {.class = "text-danger"})
    </div>

    @<Button type="submit" Class="btn btn-primary">Associar</Button>
End Using
