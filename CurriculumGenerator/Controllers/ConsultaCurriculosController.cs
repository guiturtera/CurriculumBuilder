using CurriculumGenerator.DAO;
using CurriculumGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.Controllers
{
    public class ConsultaCurriculosController : Controller
    {
        private readonly ILogger<ConsultaCurriculosController> _logger;

        public ConsultaCurriculosController(ILogger<ConsultaCurriculosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CurriculoResponseModel(true, ""));
        }

        public IActionResult ProcuraCurriculo(string CPF)
        {
            CurriculoDAO curriculoDAO = new CurriculoDAO();
            CurriculoDBViewModel curriculoViewModel = curriculoDAO.Get(CPF);

            if (curriculoViewModel == null)
                return View("Index", new CurriculoResponseModel(false, CPF, "CPF não encontrado!"));

            return View("Index", new CurriculoResponseModel(true, CPF, "", curriculoViewModel));
        }
    }
}
