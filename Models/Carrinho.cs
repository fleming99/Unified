using System.ComponentModel.DataAnnotations;

namespace MarketplaceOnline.Models
{
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataPedido { get; set; }

        [Required(ErrorMessage = "O campo ValorTotal é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O campo ValorTotal deve ser um número positivo.")]
        public double ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo StatusPedido é obrigatório.")]
        public int StatusPedido { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public Cliente Cliente { get; set; }

        // Use uma lista de Produtos em vez de Produto singular para representar vários produtos no carrinho
        public List<Produto> Produtos { get; set; }
    }
}
