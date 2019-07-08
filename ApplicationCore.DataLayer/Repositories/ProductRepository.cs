using ApplicationCore.DataLayer.EntityFramework;
using ApplicationCore.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DataLayer.Repositories
{
    public class ProductRepository: RepositoryBase
    {
        public ProductRepository(ApplicationCoreContext pContext): base(pContext)
        {

        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.Where(p => p.IsActive).OrderBy(p => p.OrderNumber).ToListAsync();
        }
    }
}
