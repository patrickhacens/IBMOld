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

namespace IBMYoung.Controllers {
    [JWTAuth]
    [Produces("application/json")]
    [Route("api")]
    public class ReplicaController : Controller {
        private readonly Db db;
        private readonly UserManager<Usuario> userManager;
        public ReplicaController(Db db, UserManager<Usuario> userManager) {
            this.db = db;
            this.userManager = userManager;
        }

        /*
            End point utilizado pelo App Mobile na ForunChatActivity
         */
        [HttpPost]
        [Route("Replica")]
        public async Task<IActionResult> Post([FromBody] ReplicaCadastroViewModel model) {
            Usuario user = db.Usuarios.SingleOrDefault(u => u.Id == model.AprendizId);

            Replica replica = new Replica();
            replica.Texto = model.Texto;
            replica.TopicoId = model.TopicoId;
            replica.DataCriacao = DateTime.Now;
            replica.Usuario = user; // await userManager.GetUserAsync(this.User);
   
            System.Console.WriteLine("[" + user.Nome + "]");

            db.Replicas.Add(replica);
            await db.SaveChangesAsync();

            return Ok();
        }

        /*
            End point utilizado pelo App Mobile na ForunChatActivity
         */
        [HttpGet]
        [Route("Replicas/{id}")]
        public List<ReplicaViewModel> List(int id) {
            List<ReplicaViewModel> lista = new List<ReplicaViewModel>();
            db.Replicas.Where(r => r.TopicoId == id)
                .Join(db.Aprendizes, r => r.Usuario.Id, a => a.Id, (r, a) => new {r, a})
                .Select(s => new {
                    s.r.Id,
                    s.r.Texto,
                    s.r.DataCriacao,
                    s.a.Nome,
                    s.a.Sobrenome
                })
                .ToList()
                .ForEach(select => lista.Add(new ReplicaViewModel {
                    Id = select.Id,
                    Texto = select.Texto,
                    DataCriacao = select.DataCriacao,
                    NomeAprendiz = select.Nome + " " + select.Sobrenome
            }));

            return lista;
        }
    }
}