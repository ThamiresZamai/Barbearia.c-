using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle
{
    public class DB : IDisposable
    {
        private SqlConnection conexao;

        public DB()
        {
            conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString);
            conexao.Open();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void ExecutarComando(string query)
        {
            var cmd = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            cmd.ExecuteNonQuery();
        }

        public void ExecutarComandoProc(string procedure, SqlCommand cmd)
        {
            cmd.CommandText = procedure;
            cmd.Connection = conexao;
            cmd.CommandType = CommandType.StoredProcedure;
            //conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoRetorno(string query)
        {
            var cmd = new SqlCommand(query, conexao);
            return cmd.ExecuteReader();
        }

        
    }
}
