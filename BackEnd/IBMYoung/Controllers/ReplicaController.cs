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
    [Route("api/Replica")]
    public class ReplicaController : Controller
    {
        Db _Db;
        public ReplicaController(Db Db)
        {
            _Db = Db;
        }
        [HttpPost]
        public Replica Post([FromBody] ReplicaCadastroViewModel model)
        {
            Replica replica = new Replica();
            replica.Texto = model.Texto;

            return replica;

            _Db.Replicas.Add(replica);
            _Db.SaveChanges();
        }

        [HttpGet]
        public List<Replica> Get()
        {
            return _Db.Replicas.ToList();
        }
    }
}