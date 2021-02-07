using System.Threading.Tasks;
using BasketAppApi.Application.BasketItems.Commands;
using BasketAppApi.Application.Baskets.Commands;
using BasketAppApi.Application.Baskets.Models;
using BasketAppApi.Application.Baskets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    //[Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetBasketsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("GetBasketByUserId/{userId}")]
        public async Task<IActionResult> GetBasketByUserId(string userId)
        {
            return Ok(await _mediator.Send(new GetBasketByUserIdQuery { Basket = new BasketByUserIdDto { UserId = userId } }));
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create()
        {
            return Ok(await _mediator.Send(new CreateBasketCommand()));
        }

        [HttpPost("AddToBasket")]
        public async Task<IActionResult> AddToBasket([FromBody] AddBasketItemToBasketCommand addItem)
        {
            return Ok(await _mediator.Send(addItem));
        }


    }
}
