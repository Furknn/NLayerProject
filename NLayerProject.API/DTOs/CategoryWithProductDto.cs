using System.Collections.Generic;

namespace NLayerProject.API.DTOs
{
    public class CategoryWithProductDto:CategoryDto
    {
        
        public ICollection<ProductDto> Products { get; set; }
    }
}