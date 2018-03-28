using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBMYoung.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ReplicaController : Controller
    {
        Db _Db;
        public ReplicaController(Db Db)
        {
            _Db = Db;
        }

        [HttpPost]
        [Route("replicas")]
        public Replica Post([FromBody] ReplicaCadastroViewModel model)
        {
            Replica replica = new Replica();
            replica.Texto = model.Texto;
            replica.TopicoId = model.TopicoId;
            replica.DataCriacao = DateTime.Now;
            replica.Usuario = _Db.Usuarios.First();//mudar isso

            _Db.Replicas.Add(replica);
            _Db.SaveChanges();

            return replica;
        }
    }
}