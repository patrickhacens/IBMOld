using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Aprendiz : Usuario
    {
        public int Nivel { get; set; }

        [Column(nameof(DataNascimento))]
        public DateTime DataNascimento { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime DataSaida { get; set; }

        public virtual Instituicao Instituicao { get; set; }

        public virtual ICollection<Boletim> Boletins { get; set; }

        public virtual Gestor Responsavel { get; set; }

        public Aprendiz(){ /*as is*/ }
        public Aprendiz(DateTime nascimento, DateTime entrada, DateTime saida, Instituicao instituicao, Gestor gestor)
        {
            this.DataNascimento = nascimento;
            this.DataEntrada = entrada;
            this.DataSaida = saida;
            this.Instituicao = instituicao;
            this.Responsavel = gestor;
        }

    }
}
