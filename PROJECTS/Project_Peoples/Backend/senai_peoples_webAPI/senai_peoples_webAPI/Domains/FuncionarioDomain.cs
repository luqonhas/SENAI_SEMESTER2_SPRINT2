using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Domains
{
    public class FuncionarioDomain
    {
        /// <summary>
        /// Esta é a classe que representa a entidade(tabela) "funcionarios"
        /// </summary>
        public int idFuncionario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime dataNascimento { get; set; }
    }
}
