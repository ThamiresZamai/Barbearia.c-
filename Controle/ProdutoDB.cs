using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace Controle
{
    public class ProdutoDB
    {
        private DB db;

        public bool insert(Produto produto)
        {
            try
            {
                string proc = "Proc_Produto_Inserir";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(new SqlParameter("@nomePro", produto.NomePro));

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

        public List<Produto> ListarProduto()
        {
            using (db = new DB())
            {
                var sql = "Proc_Produto_Listar";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);

            }
        }

        private List<Produto> TransformaSQLReaderEmList
            (SqlDataReader retorno)
        {
            var listMensagem = new List<Produto>();

            while (retorno.Read())
            {
                var item = new Produto()
                {
                    id = Convert.ToInt32(retorno["id"].ToString()),
                    NomePro = retorno["nomePro"].ToString(),
                };
                listMensagem.Add(item);
            }
            return listMensagem;
        }
    }
}
