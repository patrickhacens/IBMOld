using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBMYoung.Model;

namespace IBMYoung.Infrastructure.ViewModel {
    public class TopicoCadastroViewModel{
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    /*
        View Model utilizado pelo App Mobile na TopicoActivity
    */
    public class TopicoViewModel {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NomeAprendiz { get; set; }
    }
}
