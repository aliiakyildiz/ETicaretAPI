using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
                new() { Id = Guid.NewGuid(), Name = "Product2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
                new() { Id = Guid.NewGuid(), Name = "Product3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30 },
                new() { Id = Guid.NewGuid(), Name = "Product4", Price = 400, CreatedDate = DateTime.UtcNow, Stock = 40 }
            });
           var count= await _productWriteRepository.SaveAsync();
        }
    }
}
