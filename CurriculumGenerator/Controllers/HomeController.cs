﻿using CurriculumGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CurriculoViewModel()
            {
                CargoPretendido = "Analista",
                CPF = "123",
                Email = "abc@gotanmail.com",
                Endereco = "av abc",
                Nome = "Gui",
                PretensaoSalarial = 20000,
                Telefone = "200",

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
                    //new ExperienciasProfissionaisViewModel { Cargo = "", Descricao = "" },
                },
                ExperienciasAcademicas = new List<ExperienciasAcademicasViewModel>()
                {
                    new ExperienciasAcademicasViewModel { Curso = "Desenvolvimento front end", Descricao = "Desenvolvimento front end", DataInicio = DateTime.Now, DataFinal = DateTime.MaxValue },
                    new ExperienciasAcademicasViewModel { Curso = "Desenvolvimento back end", Descricao = "Desenvolvimento back end", DataInicio = DateTime.Now, DataFinal = DateTime.MaxValue },
                    //new ExperienciasAcademicasViewModel { Curso = "", Descricao = ""},
                    //new ExperienciasAcademicasViewModel { Curso = "", Descricao = ""},
                    //new ExperienciasAcademicasViewModel { Curso = "", Descricao = ""},
                }
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult InsereNovoCurriculo(CurriculoViewModel curriculo)
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
