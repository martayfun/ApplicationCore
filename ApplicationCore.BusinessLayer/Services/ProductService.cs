using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DataLayer.Models;
using ApplicationCore.DataLayer.Repositories;
using ApplicationCore.DataLayer.UnitOfWork;

namespace ApplicationCore.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _unitOfWork.GetRepository<ProductRepository>().GetAllAsync();
        }

        public async Task Save(Product product)
        {
            if(product.Id == 0)
            {
                await _unitOfWork.GetGenericRepository<Product>().AddAsync(product);
            }
            else
            {
                _unitOfWork.GetGenericRepository<Product>().Update(product);
            }
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
