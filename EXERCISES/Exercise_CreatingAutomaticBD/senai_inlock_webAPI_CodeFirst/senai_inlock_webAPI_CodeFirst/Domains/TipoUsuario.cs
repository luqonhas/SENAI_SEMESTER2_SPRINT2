using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_CodeFirst.Domains
{
    // define o nome da tabela que será criado no banco de dados
    [Table("tipoUsuarios")]
    public class TipoUsuario
    {
        // define que será uma chave primária(PK)
        [Key]
        // define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoUsuario { get; set; }

        // define o tipo de dado
        [Column(TypeName = "VARCHAR(255)")]
        // define que a propriedade é obrigatória
        [Required(ErrorMessage = "A permissão do tipo de usuário é obrigatória!")]
        public string permissao { get; set; }
    }
}
