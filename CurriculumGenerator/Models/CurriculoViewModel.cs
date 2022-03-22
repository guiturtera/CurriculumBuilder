using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.Models
{
    public class CurriculoViewModel
    {
        public PessoaViewModel Pessoa { get; set; }
        public List<IdiomaViewModel> Idiomas { get; set; }
        public List<ExperienciasProfissionaisViewModel> ExperienciasProfissionais { get; set; }
        public List<ExperienciasAcademicasViewModel> ExperienciasAcademicas { get; set; }
    }
}
