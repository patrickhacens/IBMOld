using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class UsuarioCadastroViewModel
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        /// <summary>
        /// Should represent either Birth or fundation dates
        /// </summary>
        public DateTime BeginDate { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Discriminator { get; set; }
    }
}
