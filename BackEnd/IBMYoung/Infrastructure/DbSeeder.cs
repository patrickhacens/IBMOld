﻿using IBMYoung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure
{
    public static class DbSeeder
    {
        public static async Task Seed(Db db)
        {

            await ClearDb(db);

            var user1 = new RecursosHumano()
            {
                Nome = "Patrick",
                Email = "patrick@gmail.com",
                Sobrenome = "Ens",
                DataNascimento = new DateTime(1994, 12, 15),

            };
            user1.SetPassword("teste1234%");
            db.Usuarios.Add(user1);

            await db.SaveChangesAsync();
        }

        private static async Task ClearDb(Db db)
        {
            db.Usuarios.RemoveRange(db.Usuarios.ToArray());
            await db.SaveChangesAsync();
        }
    }
}