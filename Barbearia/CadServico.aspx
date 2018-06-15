<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadServico.aspx.cs" Inherits="Barbearia.CadServico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/Bootstrap.css" rel="stylesheet" />
    <script src="Content/jquery-3.3.1.min.js"></script>
    <script src="Content/js/bootstrap.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro de Servico</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-sm-6">
            <br/>
            <div>
                <label>Nome:</label>
                <asp:TextBox ID="txtNomeSer" runat="server"></asp:TextBox><br />
                <br />
            </div>
            <div>
                <label>Preco:</label>
                <asp:TextBox ID="txtpreco" runat="server"></asp:TextBox><br />
            </div>
            <br />
            <div>
                <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-secondary" Text="Salvar" OnClick="btnSalvar_Click"></asp:Button><br>
            </div>

            <br />

            <table class="table table-hover table-secondary">
                <thead>
                    <tr>
                        <th scope="col">Nome do Serviço</th>
                        <th scope="col">Preco</th>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (Entidade.Servico servico in new Controle.ServicoDB().ListarServico())
                        {%>
                    <tr>
                        <td><%=servico.NomeSer %></td>
                        <td><%=servico.Preco %></td>
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
