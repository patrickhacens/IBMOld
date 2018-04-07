using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class TarefaCadastroViewModelFront
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int Nivel { get; set; }
        public List<QuestaoCadastroViewModelFront> Questoes { get; set; }
    }

    public class QuestaoCadastroViewModelFront
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string[] Alternativas { get; set; }
        public int AlternativaCorreta { get; set; }
    }
}
