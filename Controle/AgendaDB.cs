using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;

namespace Controle
{
    public class AgendaDB
    {
        private DB db;

        public bool insert(Agenda agenda)
        {
            try
            {
                string proc = "Proc_Agenda_Inserir";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(new SqlParameter("@idCliente", agenda.idCli.id));
                cmd.Parameters.Add(new SqlParameter("@data", agenda.data));
                cmd.Parameters.Add(new SqlParameter("@hora", agenda.hora));
                

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

        public List<Agenda> ListarAgenda()
        {
            using (db = new DB())
            {
                var sql = "Proc_Agenda_Listar";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);

            }
        }

        private List<Agenda> TransformaSQLReaderEmList
            (SqlDataReader retorno)
        {
            var listMensagem = new List<Agenda>();

            while (retorno.Read())
            {
                var item = new Agenda()
                {
                    id = Convert.ToInt32(retorno["id"].ToString()),
                    idCli = new Cliente() { Nome = retorno["nome"].ToString() },
                    data = retorno["data"].ToString(),
                    hora = retorno["hora"].ToString()
                };
                listMensagem.Add(item);
            }
            return listMensagem;
        }
    }
}
