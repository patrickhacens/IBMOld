using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Instituicao : Usuario
    {
        public DateTime DataFundacao { get; set; }

        public virtual ICollection<Aprendiz> Aprendizes { get; set; }

    }
}
