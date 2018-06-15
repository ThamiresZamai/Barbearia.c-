using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace Controle
{
    public class ServicoDB
    {
        private DB db;

        public bool insert(Servico servico)
        {
            try
            {
                string proc = "Proc_Servico_Inserir";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(new SqlParameter("@nomeSer", servico.NomeSer));
                cmd.Parameters.Add(new SqlParameter("@preco", servico.Preco));

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

        public List<Servico> ListarServico()
        {
            using (db = new DB())
            {
                var sql = "Proc_Servico_Listar";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);

            }
        }

        private List<Servico> TransformaSQLReaderEmList
            (SqlDataReader retorno)
        {
            var listMensagem = new List<Servico>();

            while (retorno.Read())
            {
                var item = new Servico()
                {
                    id = Convert.ToInt32(retorno["id"].ToString()),
                    NomeSer = retorno["nomeSer"].ToString(),
                    Preco = Convert.ToDecimal(retorno["preco"].ToString()),
                };
                listMensagem.Add(item);
            }
            return listMensagem;
        }
    }
}
