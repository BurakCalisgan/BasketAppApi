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
    public class GetBasketsQuery : IRequest<List<BasketDto>>
    {
        public class GetBasketsQueryHandler : IRequestHandler<GetBasketsQuery, List<BasketDto>>
        {
            private readonly IBasketAppDbContext _context;
            private readonly IMapper _mapper;
            public GetBasketsQueryHandler(IBasketAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<BasketDto>> Handle(GetBasketsQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Baskets
                                            .ToListAsync();
                return _mapper.Map<List<BasketDto>>(result);
            }
        }
    }
}