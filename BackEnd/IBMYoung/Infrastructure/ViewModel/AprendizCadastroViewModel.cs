using IBMYoung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class AprendizCadastroViewModel
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        //public UnidadeIbm unidade { get; set; }
        //public Departamento departamento { get; set; }
        //public int nivel { get; set; }
        public DateTime dataEntrada { get; set; }
        public Instituicao instituicao { get; set; }

    }
}
