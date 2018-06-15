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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListServico.DataSource = new ServicoDB().ListarServico();
                DropDownListServico.DataValueField = "id";
                DropDownListServico.DataTextField = "NomeSer";
                DropDownListServico.DataBind();

                DropDownListProduto.DataSource = new ProdutoDB().ListarProduto();
                DropDownListProduto.DataValueField = "id";
                DropDownListProduto.DataTextField = "NomePro";
                DropDownListProduto.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ServicosRealizados sr = new ServicosRealizados();
                sr.idAgenda= Convert.ToInt32(idAgendaSelecionada.Value);
                sr.idProduto = Convert.ToInt32(DropDownListProduto.SelectedValue);
                sr.idServico = Convert.ToInt32(DropDownListServico.SelectedValue);
                ServicosRealizadosDB srDB = new ServicosRealizadosDB();
                srDB.insert(sr);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Inserido com sucesso')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Erro ao inserir Registro, Erro: '" + ex.Message + ")", true);
            }
        }
    }
}