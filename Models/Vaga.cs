using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoderCarrer.Models
{
    [Table("Vaga")]
    public class Vaga
    {
        [Key]
        [Display(Name = "id_vaga")]
        [Column("id_vaga")]
        public int id_vaga { get; set; }

        [Display(Name = "titulo")]
        [Column("titulo")]
        public string? titulo { get; set; }
        [Display(Name = "salario")]
        [Column("salario")]
        public string? salario { get; set; }
        [Display(Name = "descricao_vaga")]
        [Column("descricao_vaga")]
        public string? descricao_vaga { get; set; }
        [Display(Name = "empresa")]
        [Column("empresa")]
        public string? empresa { get; set; }
        [Display(Name = "url")]
        [Column("url")]
        public string? url { get; set; }
    }
}
