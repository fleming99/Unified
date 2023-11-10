using System.ComponentModel.DataAnnotations;

namespace MarketplaceOnline.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo CategoriaNome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo CategoriaNome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome da Categoria")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O campo Descrição deve ter no máximo 200 caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
