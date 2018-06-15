<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Barbearia.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Principal</title>
     <link href="Content/Bootstrap.css" rel="stylesheet" />
    <script src="Content/jquery-3.3.1.min.js"></script>
    <script src="Content/js/bootstrap.js"></script>
    <style>
        body {
            background-color: #545454;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       

 <br/>
<h1 style="color: #f9f9f9", align="center">Minha Barbearia</h1>

<table align="center" class="espacamento">
    <tr>
    <td>
    <a class="btn btn-outline-secondary" href="CadCliente.aspx">Cadastro de Clientes</a>

    <a class="btn btn-outline-secondary" href="CadServico.aspx">Cadastro de Serviços</a>

    <a class="btn btn-outline-secondary" href="CadProduto.aspx">Cadastro de Produtos</a>

    <a class="btn btn-outline-secondary" href="CadAgenda.aspx">Agendamento</a>
 
    <a  class="btn btn-outline-secondary" href="Finalizados.aspx">Finalizados</a>
    </td>
    </tr>
</table>

<div align="center" class="espacamento">
	<img src="Imagem/barbearia.png">
</div>

<script type="text/javascript">
    function selecionado(idAgenda) {
        $('#idAgendaSelecionada').val(idAgenda);
    }
</script>
<div class="container">
<table class="table table-hover table-secondary">
        <thead>
            <tr>
                <th scope="col">Cliente</th>
                <th scope="col">Data</th>
                <th scope="col">Hora</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (Entidade.Agenda agenda in new Controle.AgendaDB().ListarAgenda())
                {%>
            <tr>
                <td><%=agenda.idCli.Nome %></td>
                <td><%=agenda.data %></td>
                <td><%=agenda.hora %></td>
                <td>
      		    <button type="button" class="btn btn-secondary" data-toggle="modal" data-target="#modalFinalizar" onclick="selecionado(<%=agenda.id %>)">Finalizar</button> 
      		    </td>
            </tr>
            <%} %>
        </tbody>
    </table>
 </div>
 <input type="hidden" id="idAgendaSelecionada" name="idAgendaSelecionada" runat="server"/>

<div class="modal fade" id="modalFinalizar" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true"> 
  <div class="modal-dialog" role="document"> 
    <div class="modal-content"> 
      <div class="modal-header"> 
        <h5 class="modal-title" id="exampleModalLabel">Finalizar Servico</h5> 
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"> 
          <span aria-hidden="true">&times;</span> 
        </button> 
      </div> 
      <div class="modal-body"> 
      <div class="form-group">
          <asp:DropDownList ID="DropDownListServico" runat="server"></asp:DropDownList>
		  
          <asp:DropDownList ID="DropDownListProduto" runat="server"></asp:DropDownList>
	   </div>
	  <div class="form-group">
          <ul id="list" class="list-inline">
          </ul>
      </div>
      </div> 
      <div class="modal-footer"> 
        <button type="button" class="btn btn-dark" data-dismiss="modal">Cancelar</button> 
          <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-light" OnClick="btnSalvar_Click" />
      </div> 
    </div> 
	</div> 
</div> 
    </form>

</body>
</html>
