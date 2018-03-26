using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class TarefaCadastroViewModel
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Entregavel { get; set; }
        public int Nivel { get; set; }
        public bool MultiEscolha { get; set; }

    }
}
