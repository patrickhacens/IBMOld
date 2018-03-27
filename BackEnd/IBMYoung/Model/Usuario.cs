using IBMYoung.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IBMYoung.Model
{

    public class Usuario : IdentityUser<int>
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string PasswordSalt { get; set; }

        public bool IsPasswordEqualsTo(string password)
        {
            return Encrypt(password, this.PasswordSalt) == this.PasswordHash;
        }

        public void SetPassword(string password)
        {
            var salt = GenerateSalt();
            this.PasswordSalt = salt.ToBase64();
            this.PasswordHash = Encrypt(password, PasswordSalt);
        }

        private static string Encrypt(string password, string salt)
        {
            byte[] toEncrypt = salt.FromBase64().Concat(Encoding.UTF8.GetBytes(password)).ToArray();
            using (var sha = SHA512.Create()) return sha.ComputeHash(toEncrypt).ToBase64();
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[64];
            using (var generator = RandomNumberGenerator.Create()) generator.GetBytes(salt);
            return salt;
        }
    }
}
