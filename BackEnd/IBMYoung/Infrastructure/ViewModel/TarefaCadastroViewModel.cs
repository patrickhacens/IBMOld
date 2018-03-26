using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class TarefaCadastroViewModel
    {
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public bool entregavel { get; set; }
        public int nivel { get; set; }
        public bool multiEscolha { get; set; }

    }
}
