using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Alternativa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TextoAlternativa { get; set; }

        public bool Correta { get; set; }

        [ForeignKey(nameof(QuestaoId))]
        public virtual Questao Questao { get; set; }

        public int QuestaoId { get; set; }
    }
}
