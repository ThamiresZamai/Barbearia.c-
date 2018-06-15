<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadAgenda.aspx.cs" Inherits="Barbearia.CadAgenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/Bootstrap.css" rel="stylesheet" />
    <script src="Content/jquery-3.3.1.min.js"></script>
    <script src="Content/js/bootstrap.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Agendamento</title>
</head>
<body>
    <form id="form1" runat="server">
        <dir class="col-sm-6">
              <br/>
        <div class="form-group">
         <label for="SelectCliente">Cliente:</label>
         <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
  </div>

        <div>
            <label>Data:</label>
             <asp:TextBox ID="txtdata" runat="server"></asp:TextBox><br/>
        </div>
        <div>
            <label>Hora:</label>
            <asp:TextBox ID="txthora" runat="server"></asp:TextBox><br/>
        </div>
        <br/>
        <div>
            <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-secondary" Text="Salvar" OnClick="btnSalvar_Click"></asp:Button>
        </div>
       </dir>
    </form>

    <br />
    <a href="Default.aspx" class="btn btn-secondary">Voltar</a>
</body>
</html>
