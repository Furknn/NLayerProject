using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Data.Seeds
{
    public class CategorySeeds : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;

        public CategorySeeds(int[] _ids)
        {
            this._ids = _ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category {Id = _ids[0], Name = "Kalemler"},
                new Category {Id = _ids[1], Name = "Defterler"}
            );
        }
    }
}