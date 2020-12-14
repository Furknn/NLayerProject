using System.ComponentModel.DataAnnotations;

namespace NLayerProject.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı boş olamaz")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1 den büyük olmalıdır")]
        public int Stock { get; set; }

        [Range(1.0, double.MaxValue, ErrorMessage = "{0} alanı 1 den büyük olmalıdır")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}