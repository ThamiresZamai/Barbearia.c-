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
    public partial class CadProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto pro = new Produto();
                pro.NomePro = txtNomePro.Text;

                ProdutoDB proDB = new ProdutoDB();
                proDB.insert(pro);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Inserido com sucesso')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Erro ao inserir Registro, Erro: '" + ex.Message + ")", true);
            }
        }
    }
}