using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_CodeFirst.Domains
{
    [Table("jogos")]
    public class Jogo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJogo { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Nome do jogo é obrigatório!")]
        public string nomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do jogo é obrigatório!")]
        public string descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lançamento do jogo é obrigatório!")]
        public DateTime dataLancamento { get; set; }

        // o decimal pode ter até 18 casas antes da vírgula e 2 casas depois da vírgula
        [Column(TypeName = "DECIMAL (18,2)")]
        [Required(ErrorMessage = "Preço do jogo é obrigatório!")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "É necessário informar o estúdio que produziu o jogo")]
        public int idEstudio { get; set; }

        [ForeignKey("idEstudio")]
        public Estudio estudio { get; set; }
    }
}
