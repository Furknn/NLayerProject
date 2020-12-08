using NLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);


    }
}
