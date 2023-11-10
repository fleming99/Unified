using System;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceOnline.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo Descrição deve ter no máximo 200 caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Preço deve ser um número positivo.")]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo Imagem é obrigatório.")]
        [Display(Name = "Imagem")]
        public string Imagem { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "O campo Vendedor é obrigatório.")]
        [Display(Name = "Vendedor")]
        public Vendedor Vendedor { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório.")]
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
    }
}
