using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Controllers
{
    public class BoletimController
    {
        Db _Db;
        public BoletimController(Db Db)
        {
            _Db = Db;
        }

        [HttpPost]
        public Boletim Post([FromBody] BoletimCadastroViewModel model)
        {
            Boletim boletim = new Boletim();
            boletim.Nota = model.nota;
            boletim.Frequencia = model.frequencia;
            boletim.MesReferencia = model.mesReferencia;
            boletim.AnoReferencia = model.anoReferencia;

            _Db.Boletins.Add(boletim);
            _Db.SaveChanges();

            return boletim;
        }

        [HttpGet]
        public List<Boletim> Get()
        {
            return _Db.Boletins.ToList();
        }

    }
}
