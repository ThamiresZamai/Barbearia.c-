<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadCliente.aspx.cs" Inherits="Barbearia.CadCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/Bootstrap.css" rel="stylesheet" />
    <script src="Content/jquery-3.3.1.min.js"></script>
    <script src="Content/js/bootstrap.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro de Cliente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-sm-6">
              <br/>
            <div>
                <label>Nome:</label>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
                <br />
            </div>
            <div>
                <label>Telefone:</label>
                <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox><br />
                <br />
            </div>
            <div>
                <label>Data nascimento:</label>
                <asp:TextBox ID="txtDtNascimento" runat="server"></asp:TextBox><br />
                <br />
            </div>
            <div>
                <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-secondary" Text="Salvar" OnClick="btnSalvar_Click"></asp:Button><br />
            </div>

            <br />
            <table class="table table-hover table-secondary">
                <thead>
                    <tr>
                        <th scope="col">Nome</th>
                        <th scope="col">telefone</th>
                        <th scope="col">Data_Nascimento</th>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (Entidade.Cliente cliente in new Controle.ClienteDB().ListarCliente())
                        {%>
                    <tr>
                        <td><%=cliente.Nome %></td>
                        <td><%=cliente.Telefone %></td>
                        <td><%=cliente.dtNascimento %></td>
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
