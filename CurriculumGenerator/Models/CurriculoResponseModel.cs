using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.Models
{
    public class CurriculoResponseModel
    {
        public CurriculoResponseModel(bool success, string cpfProcurado, string errorMessage = "", CurriculoDBViewModel curriculo = null)
        {
            Success = success;
            CpfProcurado = cpfProcurado;
            ErrorMessage = errorMessage;
            Curriculo = curriculo;
        }

        public bool Success { get; set; }
        public string CpfProcurado { get; set; }
        public string ErrorMessage { get; set; }
        public CurriculoDBViewModel Curriculo { get; set; }
    }
}
