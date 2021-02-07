using System.Threading.Tasks;
using BasketAppApi.Application.Products.Commands;
using BasketAppApi.Application.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BasketAppApi.Application.Products.Queries;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    //[Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductDto product)
        {
            return Ok(await _mediator.Send(new CreateProductCommand() { Product = product }));
        }

    }
}
