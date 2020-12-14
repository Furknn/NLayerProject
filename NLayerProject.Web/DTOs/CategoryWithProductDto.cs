using System.Collections.Generic;

namespace NLayerProject.Web.DTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}