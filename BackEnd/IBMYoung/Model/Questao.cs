using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Questao
    {
        public int Ordem { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        [ForeignKey(nameof(TarefaId))]
        public virtual Tarefa Tarefa { get; set; }

        public int TarefaId { get; set; }

        public virtual List<Alternativa> Alternativas { get; set; }
    }
}
