using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace Controle
{
    public class ServicosRealizadosDB
    {
        private DB db;

        public bool insert(ServicosRealizados servicosRealizados)
        {
            try
            {
                string proc = "Proc_Servicosrealizados_Inserir";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(new SqlParameter("@idAgenda", servicosRealizados.idAgenda));
                cmd.Parameters.Add(new SqlParameter("@idProduto", servicosRealizados.idProduto));
                cmd.Parameters.Add(new SqlParameter("@idServico", servicosRealizados.idServico));

                using (db = new DB())
                {
                    db.ExecutarComandoProc(proc, cmd);

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Finalizar> ListarFinalizar()
        {
            using (db = new DB())
            {
                var sql = "Proc_Finalizar_Listar";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);

            }
        }

        private List<Finalizar> TransformaSQLReaderEmList
            (SqlDataReader retorno)
        {
            var listMensagem = new List<Finalizar>();

            while (retorno.Read())
            {
                var item = new Finalizar()
                {
                    //id = Convert.ToInt32(retorno["id"].ToString()),
                    nome = retorno["nome"].ToString(),
                    data = retorno["data"].ToString(),
                    nomeSer = retorno["nomeSer"].ToString(),
                    nomePro = retorno["nomePro"].ToString()
                };
                listMensagem.Add(item);
            }
            return listMensagem;
        }
    }
}
