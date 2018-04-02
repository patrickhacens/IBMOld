using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model {
    public class Resposta {
        public Aprendiz Aprendiz { get; set; }
        public int AprendizId { get; set; }
        public Questao Questao { get; set; }
        public int TarefaId { get; set; }
        public int Ordem { get; set; }
        public Alternativa Alternativa { get; set; }
        public int AlternativaId { get; set; }
    }
}
