using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel {
    public class ReplicaCadastroViewModel{
        public string Texto { get; set; }
        public int TopicoId { get; set; }
        public int AprendizId { get; set; }
    }

    public class ReplicaViewModel {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NomeAprendiz { get; set; }
    }
}
