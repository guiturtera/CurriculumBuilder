using CurriculumGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.DAO
{
    public class CurriculoDAO
    {
        private SqlParameter[] CriaParametros(CurriculoViewModel curriculo)
        {
            SqlParameter[] parametros = new SqlParameter[18];
            parametros[0] = new SqlParameter("nome", curriculo.Pessoa.Nome);
            parametros[1] = new SqlParameter("CPF", curriculo.Pessoa.CPF);
            parametros[2] = new SqlParameter("endereco", curriculo.Pessoa.Endereco);
            parametros[3] = new SqlParameter("telefone", curriculo.Pessoa.Telefone);
            parametros[4] = new SqlParameter("email", curriculo.Pessoa.Email);
            parametros[5] = new SqlParameter("pretensaoSalarial", curriculo.Pessoa.PretensaoSalarial);
            parametros[6] = new SqlParameter("cargoPretendido", curriculo.Pessoa.CargoPretendido);

            // Limitado a 5 experiências.
            for (int i = 0; i < 5; i++)
            {
                string textoMontado = "";
                if (i < curriculo.ExperienciasProfissionais.Count)
                {
                    var experiencia = curriculo.ExperienciasProfissionais[i];
                    textoMontado += $"Cargo = {experiencia.Cargo}" + Environment.NewLine;
                    textoMontado += $"Descrição = {experiencia.Descricao}" + Environment.NewLine;
                    textoMontado += $"Data Inicial = {experiencia.DataInicio.Date}" + Environment.NewLine;
                    textoMontado += $"Data Final = {experiencia.DataFinal.Date}" + Environment.NewLine;
                }

                parametros[7 + i] = new SqlParameter($"experienciaProfissional{i + 1}", textoMontado);
            }

            // Limitado a 3 experiências.
            for (int i = 0; i < 3; i++)
            {
                string textoMontado = "";
                if (i < curriculo.ExperienciasAcademicas.Count)
                {
                    var experiencia = curriculo.ExperienciasAcademicas[i];
                    textoMontado += $"Curso = {experiencia.Curso}" + Environment.NewLine;
                    textoMontado += $"Descrição = {experiencia.Descricao}" + Environment.NewLine;
                    textoMontado += $"Data Inicial = {experiencia.DataInicio.Date}" + Environment.NewLine;
                    textoMontado += $"Data Final = {experiencia.DataFinal.Date}" + Environment.NewLine;
                }
                parametros[12 + i] = new SqlParameter($"experienciaAcademica{i + 1}", textoMontado);
            }

            // Limitado a 3 experiências.
            for (int i = 0; i < 3; i++)
            {
                string textoMontado = "";
                if (i < curriculo.Idiomas.Count)
                {
                    var experiencia = curriculo.Idiomas[i];
                    textoMontado += $"{experiencia.Idioma} - {experiencia.Level}" + Environment.NewLine;
                }

                parametros[15 + i] = new SqlParameter($"idioma{i + 1}", textoMontado);
            }

            return parametros;
        }

        public void Create(CurriculoViewModel curriculo)
        {
            string sql = "insert into curriculo(nome, CPF, endereco, telefone, email, pretensaoSalarial, cargoPretendido, " +
                "experienciaProfissional1, experienciaProfissional2, experienciaProfissional3, experienciaProfissional4, experienciaProfissional5," +
                "experienciaAcademica1, experienciaAcademica2, experienciaAcademica3, idioma1, idioma2, idioma3)" +
                "values (@nome, @CPF, @endereco, @telefone, @email, @pretensaoSalarial, @cargoPretendido, " +
                "@experienciaProfissional1, @experienciaProfissional2, @experienciaProfissional3, @experienciaProfissional4, @experienciaProfissional5," +
                "@experienciaAcademica1, @experienciaAcademica2, @experienciaAcademica3, @idioma1, @idioma2, @idioma3)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(curriculo));
        }

        public void Update(CurriculoViewModel curriculo)
        {
            string sql = "update curriculo set " +
                    "nome = @nome, endereco = @endereco, telefone = @telefone, email = @email, pretensaoSalarial = @pretensaoSalarial, cargoPretendido = @cargoPretendido, " +
                    "experienciaProfissional1 = @experienciaProfissional1, experienciaProfissional2 = @experienciaProfissional2, experienciaProfissional3 = @experienciaProfissional3, experienciaProfissional4 = @experienciaProfissional4, experienciaProfissional5 = @experienciaProfissional5, " +
                    "experienciaAcademica1 = @experienciaAcademica1, experienciaAcademica2 = @experienciaAcademica2, experienciaAcademica3 = @experienciaAcademica3, " +
                    "idioma1 = @idioma1, idioma2 = @idioma2, idioma3 = @idioma3 " +
                    "where CPF = @CPF";
            HelperDAO.ExecutaSQL(sql, CriaParametros(curriculo));
        }

        public CurriculoViewModel Get(string cpf)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                string sql = "select * from curriculo where CPF = " + cpf;
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
            CurriculoViewModel curriculo = new CurriculoViewModel();
            curriculo.Pessoa = new PessoaViewModel();

            curriculo.Pessoa.Nome = registro["nome"].ToString();
            curriculo.Pessoa.CPF = registro["CPF"].ToString();
            curriculo.Pessoa.Endereco = registro["endereco"].ToString();
            curriculo.Pessoa.Telefone = registro["telefone"].ToString();
            curriculo.Pessoa.Email = registro["email"].ToString();
            
            if (registro["pretensaoSalarial"].ToString() != "")
                curriculo.Pessoa.PretensaoSalarial = double.Parse(registro["pretensaoSalarial"].ToString());

            return curriculo;
        }

        internal void InsereOuAtualiza(CurriculoViewModel curriculo)
        {
            CurriculoDAO curriculoDAO = new CurriculoDAO();

            CurriculoViewModel pesssoaExistente = Get(curriculo.Pessoa.CPF);
            if (pesssoaExistente != null)
            {
                curriculoDAO.Update(curriculo);
            }
            else
            {
                curriculoDAO.Create(curriculo);
            }
        }
    }
}
