using CurriculumGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumGenerator.DAO
{
    class CurriculoDAO
    {
        /*public List<CurriculoViewModel> Get()
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                string sql = "select * from jogos";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
                {
                    DataTable tabela = new DataTable(); adapter.Fill(tabela);
                    cx.Close();

                    List<CurriculoViewModel> registers = new List<CurriculoViewModel>();

                    foreach (DataRow row in tabela.Rows)
                    {
                        registers.Add(MontaModel(row));
                    }

                    return registers;
                }
            }
        }

        public CurriculoViewModel Get(int id)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao()) 
            {
                string sql = "select * from jogos where id = " + id;
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

        private CurriculoViewModel MontaModel(DataRow registro)
        {
            CurriculoViewModel jogo = new CurriculoViewModel();

            jogo.Id = Convert.ToInt32(registro["id"]);
            jogo.Descricao = registro["descricao"].ToString();
            jogo.IdCategoria = Convert.ToInt32(registro["categoriaID"]);
            jogo.ValorLocacao = Convert.ToDecimal(registro["valor_locacao"]);
            jogo.DataAquisicao = Convert.ToDateTime(registro["data_aquisicao"]);

            return jogo;
        }

        public void Create(JogoViewModel jogo)
        {
            string sql = "insert into jogos(id, descricao, valor_locacao, data_aquisicao, categoriaID)" +
                "values (@id, @descricao, @valor_locacao, @data_aquisicao, @categoriaID)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(jogo));
        }

        public void Update(JogoViewModel jogo)
        {
            string sql = "update jogos set " +
                "descricao = @descricao, valor_locacao = @valor_locacao, data_aquisicao = @data_aquisicao, categoriaID = @categoriaID where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(jogo));
        }

        public void Delete(int id)
        {
            string sql = "delete from jogos where id = " + id;
            HelperDAO.ExecutaSQL(sql, null);
        }*/
        internal void InsereOuAtualiza(CurriculoViewModel curriculo)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            pessoaDAO.InsereOuAtualiza(curriculo.Pessoa);

            ExperienciaProfissionalDAO experienciaProfissionalDAO = new ExperienciaProfissionalDAO();
            experienciaProfissionalDAO.InsereOuAtualiza(curriculo.ExperienciasProfissionais);
        }

        public void Update(CurriculoViewModel curriculo)
        {
            
        }
    }
}
