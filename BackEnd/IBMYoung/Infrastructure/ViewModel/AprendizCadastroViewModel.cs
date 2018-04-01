using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class AprendizCadastroViewModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime Entrada { get; set; }
        public string Password { get; set; }
        
    }

    public class AprendizViewModel {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public int Nivel { get; set; }
    }

}
