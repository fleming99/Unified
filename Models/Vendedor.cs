using System.ComponentModel.DataAnnotations;

namespace MarketplaceOnline.Models
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Razão Social deve ter no máximo 100 caracteres.")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome Fantasia deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "O formato do CNPJ deve ser XX.XXX.XXX/XXXX-XX.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Range(0, 100, ErrorMessage = "A comissão deve estar entre 0 e 100.")]
        public double Comissao { get; set; }

        public Endereco Endereco { get; set; }
    }
}
