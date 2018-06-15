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
    public partial class CadAgenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = new ClienteDB().ListarCliente();
                DropDownList1.DataValueField = "id";
                DropDownList1.DataTextField = "nome";
                DropDownList1.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Agenda age = new Agenda();
                age.idCli = new Cliente() {id = Convert.ToInt32(DropDownList1.SelectedItem.Value) };
                age.data = txtdata.Text;
                age.hora = txthora.Text;

                AgendaDB ageDB = new AgendaDB();
                ageDB.insert(age);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Inserido com sucesso')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Erro ao inserir Registro, Erro: '" + ex.Message + ")", true);
            }
        }
    }
}