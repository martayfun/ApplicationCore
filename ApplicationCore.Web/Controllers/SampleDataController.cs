using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.BusinessLayer.Services;
using ApplicationCore.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        IProductService _productService;
        public SampleDataController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productService.GetProductsAsync();
        }

        [HttpPost("[action]")]
        public async Task Save([FromBody]Product product)
        {
            await _productService.Save(product);
        }
    }
}
