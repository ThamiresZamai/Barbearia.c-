using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace Controle
{
    public class ClienteDB
    {
        private DB db;

        public bool insert(Cliente cliente)
        {
            try
            {
                string proc = "Proc_Cliente_Inserir";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(new SqlParameter("@nome", cliente.Nome));
                cmd.Parameters.Add(new SqlParameter("@telefone", cliente.Telefone));
                cmd.Parameters.Add(new SqlParameter("@dtNascimento", cliente.dtNascimento));

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
        public List<Cliente> ListarCliente()
        {
            using (db = new DB())
            {
                var sql = "Proc_Cliente_Listar";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);

            }
        }

        private List<Cliente> TransformaSQLReaderEmList
            (SqlDataReader retorno)
        {
            var listMensagem = new List<Cliente>();

            while (retorno.Read())
            {
                var item = new Cliente()
                {
                    id = Convert.ToInt32(retorno["id"].ToString()),
                    Nome = retorno["nome"].ToString(),
                    Telefone = Convert.ToInt32(retorno["telefone"].ToString()),
                    dtNascimento = retorno["dtNascimento"].ToString()
                };
                listMensagem.Add(item);
            }
            return listMensagem;
        }

    }
}
