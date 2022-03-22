using CurriculumGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.DAO
{
    public class PessoaDAO
    {
        private SqlParameter[] CriaParametros(PessoaViewModel pessoa)
        {
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("nome", pessoa.Nome);
            parametros[1] = new SqlParameter("CPF", pessoa.CPF);
            parametros[2] = new SqlParameter("endereco", pessoa.Endereco);
            parametros[3] = new SqlParameter("telefone", pessoa.Telefone);
            parametros[4] = new SqlParameter("email", pessoa.Email);
            parametros[5] = new SqlParameter("pretensaoSalarial", pessoa.PretensaoSalarial);
            parametros[6] = new SqlParameter("cargoPretendido", pessoa.CargoPretendido);

            return parametros;
        }

        public void Create(PessoaViewModel pessoa)
        {
            string sql = "insert into dados_pessoais(nome, CPF, endereco, telefone, email, pretensaoSalarial, cargoPretendido)" +
                "values (@nome, @CPF, @endereco, @telefone, @email, @pretensaoSalarial, @cargoPretendido)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(pessoa));
        }

        public void Update(PessoaViewModel pessoa)
        {
            string sql = "update dados_pessoais set " +
                    "nome = @nome, endereco = @endereco, telefone = @telefone, email = @email, pretensaoSalarial = @pretensaoSalarial, cargoPretendido = @cargoPretendido where CPF = @CPF";
            HelperDAO.ExecutaSQL(sql, CriaParametros(pessoa));
        }

        public PessoaViewModel Get(string cpf)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                string sql = "select * from dados_pessoais where CPF = " + cpf;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
                {
                    DataTable tabela = new DataTable(); adapter.Fill(tabela);
                    cx.Close();

                    if (tabela.Rows.Count == 0)
                        return null;
                    else
                    {
                        DataRow registro = tabela.Rows[0];
                        return MontaModel(registro);
                    }
                }
            }
        }

        private PessoaViewModel MontaModel(DataRow registro)
        {
            PessoaViewModel pesssoa = new PessoaViewModel();

            pesssoa.Nome = registro["nome"].ToString();
            pesssoa.CPF = registro["CPF"].ToString();
            pesssoa.Endereco = registro["endereco"].ToString();
            pesssoa.Telefone = registro["telefone"].ToString();
            pesssoa.Email = registro["email"].ToString();
            
            if (registro["pretensaoSalarial"].ToString() != "")
                pesssoa.PretensaoSalarial = double.Parse(registro["pretensaoSalarial"].ToString());
            
            pesssoa.CargoPretendido = registro["cargoPretendido"].ToString();

            return pesssoa;
        }

        internal void InsereOuAtualiza(PessoaViewModel pessoa)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();

            PessoaViewModel pesssoaExistente = Get(pessoa.CPF);
            if (pesssoaExistente != null)
            {
                pessoaDAO.Update(pessoa);
            }
            else
            {
                pessoaDAO.Create(pessoa);
            }
        }
    }
}
