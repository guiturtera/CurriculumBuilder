using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumGenerator.Models
{
    public class PessoaViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CargoPretendido { get; set; }
        public double PretensaoSalarial { get; set; }
    }
}
