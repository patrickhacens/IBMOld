using IBMYoung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class AprendizCadastroViewModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        //public UnidadeIbm unidade { get; set; }
        //public Departamento departamento { get; set; }
        //public int nivel { get; set; }
        public DateTime DataEntrada { get; set; }
        public Instituicao Instituicao { get; set; }

    }
}
