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
    [Produces("application/json")]
    [Route("api/Topico")]
    public class TopicoController : Controller
    {
        private readonly Db db;
        private readonly UserManager<Usuario> userManager;
        public TopicoController(Db db, UserManager<Usuario> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<Topico> Post([FromBody] TopicoCadastroViewModel model)
        {
            Topico topico = new Topico();
            topico.Titulo = model.Titulo;
            topico.Texto = model.Texto;
            topico.DataCriacao = DateTime.Now;
            topico.Usuario = await userManager.GetUserAsync(this.User);

            db.Topicos.Add(topico);
            await db.SaveChangesAsync();

            return topico;
        }

        [HttpGet]
        public List<TopicoViewModel> Get() {
            List<TopicoViewModel> lista = new List<TopicoViewModel>();
            db.Topicos.ToList().ForEach(topico => lista.Add( new TopicoViewModel {
                Id = topico.Id,
                Titulo = topico.Titulo,
                Texto = topico.Texto,
                DataCriacao = topico.DataCriacao,
                Criador = Aprendiz(topico.Usuario.Id),
                Replicas = Replicas(topico.Replicas)

            }));

            return lista;
        }

        private AprendizViewModel Aprendiz(int id) {
            Aprendiz aprendiz = db.Aprendizes.OfType<Aprendiz>().FirstOrDefault(d => d.Id == id);
            return new AprendizViewModel() {
               Id = aprendiz.Id,
                Email = aprendiz.Email,
                Username = aprendiz.UserName,
                Nome = aprendiz.Nome,
                Sobrenome = aprendiz.Sobrenome,
                Nascimento = aprendiz.DataNascimento,
                Entrada = aprendiz.DataEntrada,
                Saida = aprendiz.DataSaida,
                Nivel = aprendiz.Nivel
            };
        }

        private ICollection<ReplicaViewModel> Replicas(ICollection<Replica> replicas) {
            List<ReplicaViewModel> lista = new List<ReplicaViewModel>();
            foreach (Replica item in replicas) {
                lista.Add(new ReplicaViewModel {
                    Id = item.Id,
                    Texto = item.Texto,
                    DataCriacao = item.DataCriacao,
                    Aprendiz = Aprendiz(item.Usuario.Id)
                });
            }
         
            return lista;
        }
    }
}