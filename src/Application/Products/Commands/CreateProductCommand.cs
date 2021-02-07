using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketAppApi.Application.Common.Interfaces;
using BasketAppApi.Application.Products.Models;
using BasketAppApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasketAppApi.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public ProductDto Product { get; set; }  
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,int>
        {
            private readonly IBasketAppDbContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;
            public CreateProductCommandHandler(IBasketAppDbContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var note = _mapper.Map<Product>(request.Product);
                _context.Products.Add(note);
                var response = await _context.SaveChangesAsync(cancellationToken);

                return response;
            }
        }
    }
}