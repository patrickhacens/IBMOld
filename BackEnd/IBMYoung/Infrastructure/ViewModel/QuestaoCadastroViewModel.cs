using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class QuestaoCadastroViewModel
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int Ordem { get; set; }
    }

    public class QuestaoViewModel {
        public int Ordem { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int TarefaId {get; set; }
    }
}
