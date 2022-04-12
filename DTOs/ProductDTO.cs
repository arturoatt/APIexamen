using System.ComponentModel.DataAnnotations;

namespace APIexamen.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
