using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Topico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public DateTime DataCriacao { get; set; }

        public virtual ICollection<Replica> Replicas { get; set; }
        
        public Usuario Usuario { get; set; }
    }
}
