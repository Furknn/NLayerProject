using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Data.Seeds
{
    public class ProductSeeds:IEntityTypeConfiguration<Product>
    {

        private readonly int[] _ids;
        public ProductSeeds(int[] _ids)
        {
            this._ids = _ids;
        }


        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product{Id = 1,Name = "Pilot Kalem",Price = 12.50m,Stock = 100,CategoryId=_ids[0]},
            new Product{Id = 2,Name = "Kurşun Kalem",Price = 4.50m,Stock = 90,CategoryId=_ids[0]},
            new Product{Id = 3,Name = "Tükenmez Kalem",Price = 10.50m,Stock = 150,CategoryId=_ids[0]},
            new Product{Id = 4,Name = "Küçük Kareli Defter",Price = 14.99m,Stock = 60,CategoryId=_ids[1]},
            new Product{Id = 5,Name = "Küçük Çizgili Defter",Price = 14.99m,Stock = 60,CategoryId=_ids[1]},
            new Product{Id = 6,Name = "Orta Kareli Defter",Price = 19.99m,Stock = 60,CategoryId=_ids[1]});
        }
    }
}