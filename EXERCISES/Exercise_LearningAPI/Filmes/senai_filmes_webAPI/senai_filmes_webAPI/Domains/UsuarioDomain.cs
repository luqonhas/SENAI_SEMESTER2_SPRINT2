using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    public class UsuarioDomain
    {
        /// <summary>
        /// Classe que representa a tabela usuários
        /// </summary>
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no mínimo 3 caracteres e no máximo 20 caracteres!")]
        public string senha { get; set; }
        public string permissao { get; set; }
    }
}
