@ModelType EmpresaAssociadoCRUD.AssociadoEmpresaModel
@Code
    ViewData("Title") = "Associar Associados"
End Code

<h2>Associar Associados à Empresa</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()

    @<div Class="form-group">
        @Html.LabelFor(Function(model) model.EmpresaId, "Selecione a Empresa:")
        @Html.DropDownListFor(Function(model) model.EmpresaId, CType(ViewBag.Empresas, IEnumerable(Of SelectListItem)), "Selecione uma Empresa", New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.EmpresaId, "", New With {.class = "text-danger"})
    </div>

    @<div Class="form-group">
        @Html.LabelFor(Function(model) model.AssociadoIds, "Selecione os Associados:")
        @Html.ListBoxFor(Function(model) model.AssociadoIds, CType(ViewBag.Associados, IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.AssociadoIds, "", New With {.class = "text-danger"})
    </div>

    @<Button type="submit" Class="btn btn-primary">Associar</Button>
End Using
