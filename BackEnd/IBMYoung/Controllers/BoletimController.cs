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
            boletim.Nota = model.Nota;
            boletim.Frequencia = model.Frequencia;
            boletim.MesReferencia = model.MesReferencia;
            boletim.AnoReferencia = model.AnoReferencia;

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
