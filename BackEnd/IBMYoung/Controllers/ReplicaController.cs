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

namespace IBMYoung.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ReplicaController : Controller
    {
        private readonly Db db;
        private readonly UserManager<Usuario> userManager;
        public ReplicaController(Db db, UserManager<Usuario> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("replicas")]
        public async Task<Replica> Post([FromBody] ReplicaCadastroViewModel model)
        {
            Replica replica = new Replica();
            replica.Texto = model.Texto;
            replica.TopicoId = model.TopicoId;
            replica.DataCriacao = DateTime.Now;
            replica.Usuario = await userManager.GetUserAsync(this.User);

            db.Replicas.Add(replica);
            await db.SaveChangesAsync();

            return replica;
        }
    }
}