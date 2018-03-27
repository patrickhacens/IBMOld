﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using IBMYoung.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IBMYoung.Infrastructure.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IBMYoung.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly Db db;
        private readonly IConfiguration configuration;

        public LoginController(Db db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<AuthResultViewModel> Login([FromBody]string username, [FromBody]string password)
        {
            Usuario user = await db.Usuarios.SingleOrDefaultAsync(usern => usern.Email == username);

            if (user == null || !user.IsPasswordEqualsTo(password)) throw new HttpException(401);

            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Tokens:Issuer"],
                                              configuration["Tokens:Audience"],
                                              claims,
                                              expires: DateTime.Now.AddYears(1),
                                              signingCredentials: creds);

            return new AuthResultViewModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
            };
        }
    }
}