using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketAppApi.Application.Common.Interfaces;
using BasketAppApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasketAppApi.Application.Baskets.Commands
{
    public class CreateBasketItemCommand : IRequest
    {
        //propertileri ekle.     
        public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommand>
        {
            private readonly IBasketAppDbContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;
            public CreateBasketItemCommandHandler(IBasketAppDbContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
            {
                var a = _context.Baskets.Add(new Basket { UserId = System.Guid.NewGuid().ToString() });
                await _context.SaveChangesAsync(cancellationToken);
                var list = await _context.Baskets.ToListAsync();
                return Unit.Value;
            }
        }
    }
}