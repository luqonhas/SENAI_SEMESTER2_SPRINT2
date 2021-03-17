using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    public class GeneroDomain
    {
        /// <summary>
        /// Esta é a classe que representa a entidade(tabela) Generos
        /// </summary>
        public int idGenero { get; set; } // aqui seria INT PK IDENTITY
        public string nome { get; set; } // aqui seria VARCHAR NOT NULL
    }
}