using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace una.Entidades
{
    public class Pessoa
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Endereco { get; set; }

        [MaxLength(16)]
        public string Telefone { get; set; }
    }
}
