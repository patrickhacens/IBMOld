using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Boletim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Nota { get; set; }
        public float Frequencia { get; set; }
        public DateTime DataCadastro { get; set; }
        public string MesReferencia { get; set; }
        public string Observacao { get; set; }
        public int AnoReferencia { get; set; }
        public virtual Aprendiz Aprendiz { get; set; }

    }
}
