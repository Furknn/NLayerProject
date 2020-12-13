using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Service
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}