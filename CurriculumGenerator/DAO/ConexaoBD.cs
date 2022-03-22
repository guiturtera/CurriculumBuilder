using System.Data.SqlClient;

namespace CurriculumGenerator.DAO
{
    public class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            string connStr = "Server= DESKTOP-TGVLOUK\\SQLEXPRESS; Database= N2B2; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}
