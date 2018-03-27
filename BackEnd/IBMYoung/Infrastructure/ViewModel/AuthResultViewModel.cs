using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure.ViewModel
{
    public class AuthResultViewModel
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public string Discriminator { get; set; }

        public int Id { get; set; }
    }
}
