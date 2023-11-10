using System.ComponentModel.DataAnnotations;

namespace MarketplaceOnline.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Rua deve ter no máximo 100 caracteres.")]
        [Display(Name = "Rua")]
        public string NomeRua { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo Número deve ter no máximo 20 caracteres.")]
        [Display(Name = "Número")]
        public string NumeroCasa { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Bairro deve ter no máximo 50 caracteres.")]
        [Display(Name = "Bairro")]
        public string NomeBairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Cidade deve ter no máximo 50 caracteres.")]
        [Display(Name = "Cidade")]
        public string NomeCidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo Estado deve ter no máximo 20 caracteres.")]
        [Display(Name = "Estado")]
        public string NomeEstado { get; set; }

        [Required(ErrorMessage = "O campo Pais é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Pais deve ter no máximo 50 caracteres.")]
        [Display(Name = "País")]
        public string NomePais { get; set; }
    }

}
