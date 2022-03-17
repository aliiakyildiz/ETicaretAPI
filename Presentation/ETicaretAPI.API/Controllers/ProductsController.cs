using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase //Bu controller test amaçlıdır.
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerReadRepository customerReadRepository,
            ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            var customerId = new Guid();
            await _customerWriteRepository.AddAsync(new() { Id = customerId, Name="Ali" });

            await _orderWriteRepository.AddAsync(new() { Description = "sdadas", Adress = "Bursa , Nilüfer", CustomerId = customerId });
            await _orderWriteRepository.AddAsync(new() { Description = "sdadas", Adress = "Bursa, Osmangazi", CustomerId = customerId });
            await _orderWriteRepository.SaveAsync();
        }

    }
}
