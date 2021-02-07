using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BasketAppApi.Application.Common.Interfaces;
using BasketAppApi.Application.Baskets.Models;

namespace BasketAppApi.Application.Baskets.Queries
{
    public class GetBasketByUserIdQuery : IRequest<BasketByUserIdDto>
    {
        public BasketByUserIdDto Basket { get; set; }
        public class GetBasketByUserIdQueryHandler : IRequestHandler<GetBasketByUserIdQuery, BasketByUserIdDto>
        {
            private readonly IBasketAppDbContext _context;
            private readonly IMapper _mapper;
            public GetBasketByUserIdQueryHandler(IBasketAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<BasketByUserIdDto> Handle(GetBasketByUserIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Baskets
                                            .Include(x => x.BasketItems)
                                            .ThenInclude(x => x.Product)
                                            .FirstOrDefaultAsync(x => x.UserId == request.Basket.UserId);
                
                return  new BasketByUserIdDto{
                    Id = result.Id,
                    UserId = result.UserId,
                    TotalPrice = result.BasketItems.Sum(x => x.Product.Price * x.Quantity),
                    BasketItems = result.BasketItems.Select(x => new BasketItemModel(){
                        BasketItemId = x.Id,
                        ProductId = x.ProductId,
                        Name = x.Product.Name,
                        Price = (decimal)x.Product.Price,
                        Quantity = x.Quantity,
                    }).ToList()
                };
            }
        }
    }
}