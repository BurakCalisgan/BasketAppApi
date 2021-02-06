using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketAppApi.Application.Products.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BasketAppApi.Application.Common.Interfaces;
namespace ToDoApi.Application.Notes.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public class GetNotesQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
        {
            private readonly IBasketAppDbContext _context;
            private readonly IMapper _mapper;
            public GetNotesQueryHandler(IBasketAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Products
                .ToListAsync();

                return _mapper.Map<List<ProductDto>>(result);
            }
        }
    }
}