<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finalizados.aspx.cs" Inherits="Barbearia.Finalizados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Finalizados</title>
    <link href="Content/Bootstrap.css" rel="stylesheet" />
    <script src="Content/jquery-3.3.1.min.js"></script>
    <script src="Content/js/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <br/>
<a href="Default.aspx" class="btn btn-secondary">Voltar</a>
<br/>
<div class="container">
<table class="table table-hover table-secondary" align="center">
  <thead>
    <tr>
      <th scope="col">Cliente</th>
      <th scope="col">Data</th>
      <th scope="col">Serviço</th>
      <th scope="col">Produto</th>
    </tr>
  </thead>
  <tbody>
  
  <%foreach(Entidade.Finalizar finalizar in new Controle.ServicosRealizadosDB().ListarFinalizar()) {%> 
    <tr> 
       <td><%=finalizar.nome %></td>
       <td><%=finalizar.data %></td> 
      <td><%=finalizar.nomeSer %></td> 
      <td><%=finalizar.nomePro %></td> 		
    </tr> 
    <%} %> 
  </tbody>
</table>
</div>
    </form>
</body>
</html>
