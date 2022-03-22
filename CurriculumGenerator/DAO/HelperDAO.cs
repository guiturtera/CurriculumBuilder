using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumGenerator.DAO
{
    class HelperDAO
    {
        public static void ExecutaSQL(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao)) 
                {
                    if (parametros != null) 
                        comando.Parameters.AddRange(parametros); 
                    comando.ExecuteNonQuery();
                } 
                conexao.Close();
            } 
        }
    }
}
