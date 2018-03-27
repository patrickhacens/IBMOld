using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Resposta
    {
        public int Id { get; set; }

        public Aprendiz Aprendiz { get; set; }

        public Questao Questao { get; set; }

        public int MyProperty { get; set; }
    }
}
