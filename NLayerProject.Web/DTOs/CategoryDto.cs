using System.ComponentModel.DataAnnotations;

namespace NLayerProject.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }
    }
}