using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.Models
{
    public class CurriculoDBViewModel
    {
        public PessoaViewModel Pessoa { get; set; }
        public string ExperienciaProfissional1 { get; set; }
        public string ExperienciaProfissional2 { get; set; }
        public string ExperienciaProfissional3 { get; set; }
        public string ExperienciaProfissional4 { get; set; }
        public string ExperienciaProfissional5 { get; set; }

        public string ExperienciaAcademica1 { get; set; }
        public string ExperienciaAcademica2 { get; set; }
        public string ExperienciaAcademica3 { get; set; }

        public string Idioma1 { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }
    }
}
