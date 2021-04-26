using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_CodeFirst.Domains
{
    [Table("estudios")]
    public class Estudio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstudio { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
        public string nomeEstudio { get; set; }

        public List<Jogo> jogos { get; set; }
    }
}
