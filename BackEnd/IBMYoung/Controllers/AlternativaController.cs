using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBMYoung.Controllers
{
    [JWTAuth]
    [Produces("application/json")]
    [Route("api")]
    public class AlternativaController : Controller
    {
        private readonly Db db;

        public AlternativaController(Db db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("Alternativa/{tarefaId}/{ordem}")]
        public async Task<Alternativa> PostAlternativa(int tarefaId, int ordem, [FromBody] AlternativaCadastroViewModel model)
        {
            var questao = await db.Questoes
                .Include(d => d.Alternativas)
                .FirstOrDefaultAsync(d => d.TarefaId == tarefaId && d.Ordem == ordem);
            if (questao == null) throw new HttpException(404);

            if (model.Correta && questao.Alternativas.Any(d => d.Correta))
                foreach (var alternativa in questao.Alternativas)
                    alternativa.Correta = false;

            var result = new Alternativa()
            {
                Correta = model.Correta,
                Questao = questao,
                TextoAlternativa = model.TextoAlternativa
            };

            questao.Alternativas.Add(result);

            await db.SaveChangesAsync();
            return result;
        }

        [HttpGet]
        [Route("Alternativa/{id}")]
        public async Task<Alternativa> Get(int id)
        {
            var alternativa = await db.Alternativas
                .Include(d => d.Questao.Tarefa)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (alternativa == null) throw new HttpException(404);

            return alternativa;
        }

        [HttpPut]
        [Route("Alternativa/{id}")]
        public async Task<Alternativa> Put(int id, AlternativaCadastroViewModel model)
        {
            var alternativa = await db.Alternativas
                .Include(d => d.Questao.Tarefa)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (alternativa == null) throw new HttpException(404);

            alternativa.TextoAlternativa = model.TextoAlternativa;
            alternativa.Correta = model.Correta;

            if (alternativa.Correta && alternativa.Questao.Alternativas.Any(d => d.Correta && d != alternativa))
                foreach (var alt in alternativa.Questao.Alternativas.Where(d => d.Correta && d != alternativa).ToArray())
                    alt.Correta = false;

            await db.SaveChangesAsync();
            return alternativa;
        }
    }
}