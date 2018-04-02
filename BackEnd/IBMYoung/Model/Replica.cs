using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model {
    public class Replica {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        [ForeignKey(nameof(TopicoId))]
        public virtual Topico Topico { get; set; }
        public int TopicoId { get; set; }
    
        public Usuario Usuario { get; set; }
    }
}
