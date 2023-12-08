using Aplication.Commands;
using Aplication.Commands.Products;
using Aplication.Commands.Sales;
using Aplication.Dtos;
using Aplication.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController 
    {
        private readonly ICommandBus commandBus;

        public SalesController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        [HttpGet("{id}")]
        public IResponse GetSale(int id)
        {
            return commandBus.execute(new GetSale { Id = id });
        }

        [HttpPost]
        public IResponse CreateProduct([FromBody] SaleDto value)
        {
            return commandBus.execute(new CreateSale { Sale = value });
        }

        [HttpGet("listSales", Name = "listSales")]
        public IResponse GetSales()
        {
            var respuesta = commandBus.execute(new GetAllSales { });
            return respuesta;
        }

    }
}
