using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Controllers
{
    [JWTAuth]
    [Produces("application/json")]
    [Route("api/[controller]")]
        public class BoletimController
    {
        private readonly Db db;
        public BoletimController(Db db)
        {
            this.db = db;
        }

        [HttpPost]
        public async Task<Boletim> Post([FromBody] BoletimCadastroViewModel model)
        {
            var aprendiz = await db.Usuarios.OfType<Aprendiz>().FirstOrDefaultAsync(d => d.Id == model.AprendizId);
            if (aprendiz == null) throw new HttpException(404);

            Boletim boletim = new Boletim()
            {
                Aprendiz = aprendiz,
                Nota = model.Nota,
                Frequencia = model.Frequencia,
                MesReferencia = model.MesReferencia,
                AnoReferencia = model.AnoReferencia,
            };

            db.Boletins.Add(boletim);
            await db.SaveChangesAsync();

            return boletim;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Boletim> Put(int id, [FromBody]BoletimCadastroViewModel model)
        {
            var boletim = await db.Boletins.Include(d => d.Aprendiz).FirstOrDefaultAsync(d => d.Id == id);
            if (boletim == null) throw new HttpException(404);

            boletim.Nota = model.Nota;
            boletim.Frequencia = model.Frequencia;
            boletim.MesReferencia = model.MesReferencia;
            boletim.AnoReferencia = model.AnoReferencia;

            await db.SaveChangesAsync();
            return boletim;
        }

        [HttpGet]
        public async Task<List<Boletim>> Get() => await db.Boletins.Include(d => d.Aprendiz).ToListAsync();

    }
}
