using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IBMYoung.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        Db _Db;
        IConfiguration _configuration;
        public UsuarioController(Db Db, IConfiguration configuration)
        {
            _Db = Db;
            _configuration = configuration;
        }

        public class TokenRequest
        {
            public string Password { get; set; }
            public string Username { get; set; }
        }
     
        [Authorize]
        [HttpGet]
        public List<Usuario> Get()
        {
 
            return _Db.Usuarios.ToList();
        }
    }
}