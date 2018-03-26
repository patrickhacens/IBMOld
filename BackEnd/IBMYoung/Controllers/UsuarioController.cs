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
     
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]   TokenRequest request)
        {
            //if (request.Username == "teste" && request.Password == "teste")

            Usuario objeto = _Db.Usuarios.Where(x => x.Username == request.Username && x.Password == request.Password).FirstOrDefault();

            if (objeto != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                HttpContext.Response.Headers.Add("token", token.ToString());

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    //tipo = objeto.tipo
                });
            }

            return BadRequest("Usuário ou senha inválidos");
        }

        [HttpPost]
        public Usuario Post([FromBody] UsuarioCadastroViewModel model)
        {
            Usuario usuario = new Usuario();
            usuario.Active = true;
            usuario.Password = model.password;
            usuario.Username = model.username;

            _Db.Usuarios.Add(usuario);
            _Db.SaveChanges();

            return usuario;
        }

        [Authorize]
        [HttpGet]
        public List<Usuario> Get()
        {
 
            return _Db.Usuarios.ToList();
        }
    }
}