using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    public class FilmeDomain
    {
        /// <summary>
        /// Esta é a classe que representa a entidade(tabela) Filmes
        /// </summary>
        public int idFilme { get; set; } // aqui seria INT PK IDENTITY
        public string titulo { get; set; } // aqui seria VARCHAR NOT NULL
        public int idGenero { get; set; } // aqui seria INT FK REFERENCES GeneroDomain(idGenero PK)
        public GeneroDomain genero { get; set; } // aqui está sendo instanciado o Domain dos gêneros para conseguir usar o INNER JOIN
    }
}
