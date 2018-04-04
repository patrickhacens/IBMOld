using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class TarefaViewModel {
        public int Nivel { get; set; }
        public IEnumerable<QuestaoViewModel> Questoes { get; set; }
    }
    /*
        View Movel utilizado pelo App Mobile na TarefasActivity
    */
    public class TarefaAdapterViewModel {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Nivel { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Respondida { get; set; }
        public bool Correta { get; set; }
    }
}
