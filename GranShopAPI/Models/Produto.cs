using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranShopAPI.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public int CateogriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        [Column(TypeName = "Numeric(10,2)")]
        public decimal ValorCusto { get; set; }

        [Required]
        [Column(TypeName = "Numeric(10,2)")]
        public decimal ValorVenda { get; set; }

        [Required]
        public bool Destaque { get; set; }
    }
}
