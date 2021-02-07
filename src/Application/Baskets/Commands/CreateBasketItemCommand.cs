using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketAppApi.Application.Common.Interfaces;
using BasketAppApi.Domain.Entities;
using MediatR;

namespace BasketAppApi.Application.Baskets.Commands
{
    public class CreateBasketCommand : IRequest
    {
        //propertileri ekle.     
        public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand>
        {
            private readonly IBasketAppDbContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;
            public CreateBasketCommandHandler(IBasketAppDbContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
            {
                //Burada her userın bir sepeti varmış mantığı ile dummy olarak userın sepeti oluşturuluyor.
                _context.Baskets.Add(new Basket { UserId = System.Guid.NewGuid().ToString() });
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}