using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controle;
using Entidade;

namespace Barbearia
{
    public partial class CadCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cli = new Cliente();
                cli.Nome = txtNome.Text;
                cli.Telefone = Convert.ToInt32(txtTelefone.Text);
                cli.dtNascimento = txtDtNascimento.Text;

                ClienteDB cliDB = new ClienteDB();
                cliDB.insert(cli);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Inserido com sucesso')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Erro ao inserir Registro, Erro: '"+ ex.Message +")", true);
            }
        }
    }
}