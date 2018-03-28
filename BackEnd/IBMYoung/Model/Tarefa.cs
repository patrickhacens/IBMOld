using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataExclusao { get; set; }

        public int Nivel { get; set; }

        public string Conteudo { get; set; }

        public bool Active { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public virtual ICollection<Questao> Questoes { get; set; }

    }
}
