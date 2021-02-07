using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketAppApi.Application.Common.Interfaces;
using BasketAppApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasketAppApi.Application.BasketItems.Commands
{
    public class AddBasketItemToBasketCommand : IRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public class AddBasketItemToBasketCommandHandler : IRequestHandler<AddBasketItemToBasketCommand>
        {
            private readonly IBasketAppDbContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;
            public AddBasketItemToBasketCommandHandler(IBasketAppDbContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(AddBasketItemToBasketCommand request, CancellationToken cancellationToken)
            {
                var userBasket = await _context.Baskets
                                           .Include(x => x.BasketItems)
                                           .ThenInclude(x => x.Product)
                                           .FirstOrDefaultAsync(x => x.UserId == request.UserId);

                if (userBasket != null)
                {
                    var index = userBasket.BasketItems.FindIndex(i => i.ProductId == request.ProductId);

                    if (index < 0)
                    {
                        userBasket.BasketItems.Add(new BasketItem()
                        {
                            ProductId = request.ProductId,
                            Quantity = request.ProductId,
                            BasketId = userBasket.Id
                        });
                    }
                    else
                    {
                        userBasket.BasketItems[index].Quantity += request.Quantity;
                    }

                    _context.Baskets.Update(userBasket);
                }

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}