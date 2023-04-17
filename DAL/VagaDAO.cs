using CoderCarrer.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CoderCarrer.DAL
{
    public class VagaDAO
    {
        private MySqlConnection _conexao;
        public VagaDAO()
        {
           // _conexao = ConexaoBD.getConexao();
        }
        public List<Vaga> getTodosVagas()
        {
            string sql = "select * from vagas_ti";
            var dados = (List<Vaga>)_conexao.Query<Vaga>(sql);
            return dados;

        }

    }
}