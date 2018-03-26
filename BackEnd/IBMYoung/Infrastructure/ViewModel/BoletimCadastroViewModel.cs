using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class BoletimCadastroViewModel
    {
        public float Nota { get; set; }
        public float Frequencia { get; set; }
        public string MesReferencia { get; set; }
        public string Observacao { get; set; }
        public int AnoReferencia { get; set; }
    }
}
