using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Aprendiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Nivel { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime DataSaida { get; set; }

        [ForeignKey(nameof(InstituicaoId))]
        public virtual Instituicao Instituicao { get; set; }

        public int InstituicaoId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public virtual Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public virtual ICollection<Boletim> Boletins { get; set; }

        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
