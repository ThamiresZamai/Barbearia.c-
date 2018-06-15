<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadProduto.aspx.cs" Inherits="Barbearia.CadProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/Bootstrap.css" rel="stylesheet" />
    <script src="Content/jquery-3.3.1.min.js"></script>
    <script src="Content/js/bootstrap.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro Produto</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-sm-6">
              <br/>
            <div>
                <label>Nome do Produto:</label>
                <asp:TextBox ID="txtNomePro" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-secondary" Text="Salvar" OnClick="btnSalvar_Click"></asp:Button>
            </div>

            <br />

            <table class="table table-hover table-secondary">
                <thead>
                    <tr>
                        <th scope="col">Nome do Produto</th>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (Entidade.Produto servico in new Controle.ProdutoDB().ListarProduto())
                        {%>
                    <tr>
                        <td><%=servico.NomePro %></td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
    </form>
    <br />
    <a href="Default.aspx" class="btn btn-secondary">Voltar</a>
</body>
</html>
