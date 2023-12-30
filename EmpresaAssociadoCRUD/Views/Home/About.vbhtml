@Code
    ViewData("Title") = "About"
End Code

<h2>@ViewData("Title")</h2>
<h3>@ViewData("Message")</h3>

<p>
    1. Criar cadastro de associados com os seguintes campos:
    <ul>
        <li>1.1. Id (int, auto incrementável)</li>
        <li>1.2 Nome (varchar, 200, não nulo)</li>
        <li>1.3 Cpf (varchar, 11, não nulo)</li>
        <li>1.4 Data de Nascimento (DateTime)</li>
    </ul>
    2. Criar cadastro de empresas com os seguintes campos:
    <ul>
        <li>2.1. Id(int, auto incrementável)</li>
        <li>2.2. Nome(varchar, 200, não nulo)</li>
        <li>2.3. CNPJ (varchar, 14, não nulo)</li>
    </ul>
    3. Criar o Relacionamento N pra N entre associado e empresa. <br />
    4. Cada cadastro citado acima (itens 1 e 2) deve possuir as APIs de inclusão, alteração, consulta por filtros retornando uma lista como resultado, consulta por id retornando o objeto como resultado, e exclusão, tendo como parâmetro o id do mesmo. <br />
    5. Os campos CPF e CNPJ devem ser únicos. <br />
    6. Na inclusão do associado deve ser possível adicionar 1 ou mais empresas. <br />
    7. Na inclusão da empresa deve ser possível adicionar 1 ou mais associados. <br />
    8. Na alteração de associado deve ser possível, além de alterar os dados cadastrais do mesmo, adicionar ou remover uma empresa vinculado a ele. <br />
    9. Na alteração da empresa deve ser possível, além de alterar os dados cadastrais da mesma, adicionar ou remover um associado vinculado a ela. <br />
    10. Na exclusão de associado, remover as empresas do relacionamento sem excluí-las. <br />
    11. Na exclusão da empresa, remover os associados do relacionamento sem excluí-los. <br />
    12. Os filtros das consultas serão os campos de cada tabela, não sendo necessário colocar o filtro por relacionamento. <br />
    <br />
    A tecnologia a ser utilizada: <br />
    WebForms ADO .NET (vb.net) <br />
    Banco de Dados Sql Server <br />
</p>
