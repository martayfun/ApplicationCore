using ApplicationCore.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.BusinessLayer.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task Save(Product product);
    }
}
