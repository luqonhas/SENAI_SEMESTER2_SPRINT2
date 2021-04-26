using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_CodeFirst.Domains
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        public string email { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatório!")]
        // define os requisitos da propriedade
        [StringLength(150, MinimumLength = 5, ErrorMessage = "A senha deve conter de 5 a 150 caracteres.")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }

        // define a chave estrangeira
        [ForeignKey("idTipoUsuario")]
        public TipoUsuario tipoUsuario { get; set; }
    }
}
