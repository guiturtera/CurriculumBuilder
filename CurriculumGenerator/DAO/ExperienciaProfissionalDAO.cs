using CurriculumGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.DAO
{
    public class ExperienciaProfissionalDAO
    {
        private SqlParameter[] CriaParametros(ExperienciasAcademicasViewModel experiencia)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("curso", experiencia.Curso);
            parametros[1] = new SqlParameter("descricao", experiencia.Descricao);
            parametros[2] = new SqlParameter("data_inicio", experiencia.DataInicio);
            parametros[3] = new SqlParameter("data_final", experiencia.DataFinal);

            return parametros;
        }

        public void Create(ExperienciasAcademicasViewModel experiencia)
        {
            string sql = "insert into experiencias_profissionais(curso, descricao, data_inicio, data_final)" +
                "values (@curso, @descricao, @data_inicio, @data_final)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(experiencia));
        }

        public void Update(ExperienciasAcademicasViewModel experiencia)
        {
            string sql = "update dados_pessoais set " +
                    "curso = @curso, descricao = @descricao, data_inicio = @data_inicio, data_final = @data_final where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(experiencia));
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
