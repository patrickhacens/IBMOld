using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class TarefaViewModel
    {
        public int Nivel { get; set; }

        public IEnumerable<QuestaoViewModel> Questoes { get; set; }
    }

    public class QuestaoViewModel
    {
        public int TarefaId { get; set; }

        public int Ordem { get; set; }

        public string Descricao { get; set; }

        public bool Respondida { get; set; }

        public IEnumerable<AlternativaViewModel> Alternativas { get; set; }
    }

    public class AlternativaViewModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

    }
}
