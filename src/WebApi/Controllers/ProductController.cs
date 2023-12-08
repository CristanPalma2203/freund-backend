using Aplication.Commands;
using Aplication.Commands.Products;
using Aplication.Dtos;
using Aplication.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController 
    {
        private readonly ICommandBus commandBus;

        public ProductController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        [HttpGet("{id}")]
        public IResponse GetProduct(int id)
        {
            return commandBus.execute(new GetProduct {Id = id });
        }

        [HttpPost]
        public IResponse CreateProduct([FromBody] ProductDto value)
        {
            return commandBus.execute(new CreateProduct { Product = value });
        }

        [HttpPut]
        public void UpdateProduct([FromBody] ProductDto value)
        {
            commandBus.execute(new UpdateProduct { Product = value });
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            commandBus.execute(new DeleteProduct { Id = id });
        }

        [HttpGet("listProducts", Name = "listProducts")]
        public IResponse GetProducts()
        {
            var respuesta = commandBus.execute(new GetProducts { });
            return respuesta;
        }
    }
}
