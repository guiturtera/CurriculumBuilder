using CurriculumGenerator.DAO;
using CurriculumGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CurriculumGenerator.Controllers
{
    public class EditorDeCurriculosController : Controller
    {
        public IActionResult Index()
        {
            return View(new CurriculoViewModel()
            {
                Pessoa = new PessoaViewModel()
                {
                    CargoPretendido = "Analista",
                    CPF = "123",
                    Email = "abc@gotanmail.com",
                    Endereco = "av abc",
                    Nome = "Gui",
                    PretensaoSalarial = 20000,
                    Telefone = "200",
                },
                Idiomas = new List<IdiomaViewModel>()
                {
                    new IdiomaViewModel { Idioma = "Inglês", Level = "Avançado" },
                    new IdiomaViewModel { Idioma = "Português", Level = "Fluente" },
                    new IdiomaViewModel { Idioma = "Espanhol", Level = "Iniciante" },
                },
                ExperienciasProfissionais = new List<ExperienciasProfissionaisViewModel>()
                {
                    new ExperienciasProfissionaisViewModel { Cargo = "Analista Júnior", Descricao = "Analista júnior", DataInicio = DateTime.Now, DataFinal = DateTime.MaxValue },
                    new ExperienciasProfissionaisViewModel { Cargo = "Analista Júnior 2", Descricao = "Analista pleno", DataInicio = DateTime.Now, DataFinal = DateTime.MaxValue },
                },
                ExperienciasAcademicas = new List<ExperienciasAcademicasViewModel>()
                {
                    new ExperienciasAcademicasViewModel { Curso = "Desenvolvimento front end", Descricao = "Desenvolvimento front end", DataInicio = DateTime.Now, DataFinal = DateTime.MaxValue },
                    new ExperienciasAcademicasViewModel { Curso = "Desenvolvimento back end", Descricao = "Desenvolvimento back end", DataInicio = DateTime.Now, DataFinal = DateTime.MaxValue },
                }
            });
        }

        public IActionResult InsereNovoCurriculo(CurriculoViewModel curriculo)
        {
            try
            {
                CurriculoDAO curriculoDAO = new CurriculoDAO();
                curriculoDAO.InsereOuAtualiza(curriculo);

                return Ok("Sucesso ao criar/atualizar currículo!");
            }
            catch
            {
                return Ok("Por favor, tente novamente mais tarde." +
                    "Falha ao inserir informação no banco de dados.");
            }
        }
    }
}
