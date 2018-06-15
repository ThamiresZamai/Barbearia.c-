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
    public partial class CadServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Servico ser = new Servico();
                ser.NomeSer = txtNomeSer.Text;
                ser.Preco = Convert.ToDecimal(txtpreco.Text);

                ServicoDB serDB = new ServicoDB();
                serDB.insert(ser);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Inserido com sucesso')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Erro ao inserir Registro, Erro: '" + ex.Message + ")", true);
            }
        }
    }
}