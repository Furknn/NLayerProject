using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Service
{
    public interface IProductService:IService<Product>
    {
        Task<Product> GettWithCategoryByIdAsync(int productId);
    }
}