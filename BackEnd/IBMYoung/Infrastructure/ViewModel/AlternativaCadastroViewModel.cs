using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel {
    public class AlternativaCadastroViewModel {
        public string TextoAlternativa { get; set; }
        public bool Correta { get; set; }
    }

    /*
        View Model  utilizado pelo App Mobile na AlternativasActivity
     */
    public class AlternativaViewModel {
        public int Id { get; set; }
        public string TextoAlternativa { get; set; }
        public bool Correta { get; set; }
    }
}
