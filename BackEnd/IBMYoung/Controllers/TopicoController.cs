using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBMYoung.Controllers
{
    [JWTAuth]
    [Produces("application/json")]
    [Route("api")]
    public class TopicoController : Controller {
        private readonly Db db;
        private readonly UserManager<Usuario> userManager;
        public TopicoController(Db db, UserManager<Usuario> userManager) {
            this.db = db;
            this.userManager = userManager;
        }

        /*
            End point utilizado pelo App Mobile na ForunActivity
         */
        [HttpPost]
        [Route("Topico")]
        public async Task<Topico> Post([FromBody]  TopicoCadastroViewModel model) {
            Aprendiz aprendiz = db.Aprendizes.SingleOrDefault(u => u.Id == model.AprendizId);
            if (aprendiz == null) throw new HttpException(401, new { Mensagem = "Aprendiz não foi encontrado" });
 
            Topico topico = new Topico {
                Titulo = model.Titulo,
                Texto = model.Texto,
                DataCriacao = DateTime.Now,
                Usuario = aprendiz
            };

            db.Topicos.Add(topico);
            await db.SaveChangesAsync();

            return topico;
        }

        /*
            End point utilizado pelo App Mobile na ForunActivity
         */
        [HttpGet]
        [Route("Topicos")]
        public List<TopicoViewModel> List() {
            List<TopicoViewModel> lista = new List<TopicoViewModel>();
            db.Topicos
                .Join(db.Aprendizes, r => r.Usuario.Id, a => a.Id, (r, a) => new {r, a})
                .Select(s => new {
                    s.r.Id,
                    s.r.Titulo,
                    s.r.Texto,
                    s.r.DataCriacao,
                    s.a.Nome,
                    s.a.Sobrenome
                })
                .ToList().ForEach(select => lista.Add( new TopicoViewModel {
                    Id = select.Id,
                    Titulo = select.Titulo,
                    Texto = select.Texto,
                    DataCriacao = select.DataCriacao,
                    NomeAprendiz = select.Nome + " " + select.Sobrenome
            }));

            return lista;
        }

        /*
            End point utilizado pelo App Mobile na ForunActivity
         */
        [HttpGet]
        [Route("Topico/{id}")]
        public TopicoViewModel Get(int id) {
            var topico = db.Topicos.Where(t => t.Id == id)
                .Join(db.Aprendizes, r => r.Usuario.Id, a => a.Id, (r, a) => new {r, a})
                .Select(s => new {
                    s.r.Id,
                    s.r.Titulo,
                    s.r.Texto,
                    s.r.DataCriacao,
                    s.a.Nome,
                    s.a.Sobrenome
                })
                .FirstOrDefault();
            return new TopicoViewModel {
                    Id = topico.Id,
                    Titulo = topico.Titulo,
                    Texto = topico.Texto,
                    DataCriacao = topico.DataCriacao,
                    NomeAprendiz = topico.Nome + " " + topico.Sobrenome
            };
        }
    }
}