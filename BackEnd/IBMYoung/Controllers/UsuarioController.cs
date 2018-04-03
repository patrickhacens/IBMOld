using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IBMYoung.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [JWTAuth]
    public class UsuarioController : Controller
    {
        private readonly Db db;
        private readonly Configuration config;
        private readonly UserManager<Usuario> userManager;
        public UsuarioController(Db db, Configuration config, UserManager<Usuario> userManager)
        {
            this.db = db;
            this.config = config;
            this.userManager = userManager;
        }

        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Usuario> Get() => db.Usuarios.ToList();

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<Usuario> Post([FromBody]UsuarioCadastroViewModel model)
        {
            Usuario user = default(Usuario);
            switch (model.Discriminator)
            {
                case nameof(Instituicao):
                    user = new Instituicao(model.BeginDate);
                    break;
                case nameof(Gestor):
                    user = new Gestor(model.BeginDate);
                    break;
                case nameof(RecursosHumano):
                    user = new RecursosHumano(model.BeginDate);
                    break;
                default:
                    throw new HttpException(422);
                    break;
            }

            user.Email = model.Email;
            user.SetPassword(model.Password);
            user.UserName = model.Username;
            user.Nome = model.Nome;
            user.Sobrenome = model.Sobrenome;

            db.Usuarios.Add(user);
            await db.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// Cria vários aprendizes
        /// </summary>
        /// <param name="id">Id do gestor</param>
        /// <param name="instituicaoId">Id do instrutor</param>
        /// <param name="file">Csv com formato especifico, para ver o formato vide GenerateFile()</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> BatchPost(int id, int instituicaoId, IFormFile file)
        {
            Gestor gestor = await db.Usuarios.OfType<Gestor>().FirstOrDefaultAsync(d => d.Id == id);
            if (gestor == null) return NotFound();

            Instituicao instituicao = await db.Usuarios.OfType<Instituicao>().FirstOrDefaultAsync(d => d.Id == instituicaoId);
            if (instituicao == null) return NotFound();

            using (var stream = file.OpenReadStream())
            using (StreamReader sr = new StreamReader(stream))
            using (CsvReader reader = new CsvReader(sr, config))
            {
                Usuario[] aprendizes = reader.GetRecords<AprendizViewModel>()
                    .Select(d => new Aprendiz(d.Nascimento, d.Entrada, d.Saida, instituicao, gestor)
                    {
                        Email = d.Email,
                        UserName = d.Username,
                        Nome = d.Nome,
                        Sobrenome = d.Sobrenome
                    }.SetPassword(d.Nascimento.ToShortDateString())).ToArray();

                db.Usuarios.AddRange(aprendizes);
                await db.SaveChangesAsync();
            }

            return Ok();
        }

        /// <summary>
        /// Retorna o formato do formulário de aprendizes
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("csv")]
        public async Task<IActionResult> GenerateFile()
        {
            MemoryStream ms = new MemoryStream();

            using (StreamWriter sw = new StreamWriter(ms, Encoding.UTF8, 2 << 10, true))
            using (CsvWriter writer = new CsvWriter(sw, config))
            {
                writer.Context.LeaveOpen = true;
                writer.WriteHeader<AprendizViewModel>();
            }
            ms.Position = 0;

            return File(ms, "text/csv", "template.csv");
        }

        /// <summary>
        /// Visualiza o perfil do usuário logado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("me")]
        public async Task<Usuario> Me()
        {
            return await userManager.GetUserAsync(this.User);
        }
    }
}