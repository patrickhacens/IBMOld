﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Model
{
    public class Gestor : Usuario
    {
        [Column(nameof(DataNascimento))]
        public DateTime DataNascimento { get; set; }
        public ICollection<Aprendiz> Aprendizes { get; set; }
    }

    public class RecursosHumano : Usuario
    {
        [Column(nameof(DataNascimento))]
        public DateTime DataNascimento { get; set; }
    }
}
