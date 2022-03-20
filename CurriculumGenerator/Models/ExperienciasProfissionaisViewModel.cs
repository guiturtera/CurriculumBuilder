using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.Models
{
    public class ExperienciasProfissionaisViewModel
    {
        public string Cargo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
