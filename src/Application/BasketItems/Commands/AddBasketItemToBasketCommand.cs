using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketAppApi.Application.Common.Exceptions;
using BasketAppApi.Application.Common.Interfaces;
using BasketAppApi.Application.Common.Models;
using BasketAppApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BasketAppApi.Application.BasketItems.Commands
{
    public class AddBasketItemToBasketCommand : IRequest<ResponseObject>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public class AddBasketItemToBasketCommandHandler : IRequestHandler<AddBasketItemToBasketCommand, ResponseObject>
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
            public async Task<ResponseObject> Handle(AddBasketItemToBasketCommand request, CancellationToken cancellationToken)
            {
                ResponseObject response = new ResponseObject();
                response.ReturnCode = ReturnCode.Success;
                response.ReturnMessage = "İşleminiz başarıyla gerçekleştirilmiştir.";
                try
                {

                    var userBasket = await _context.Baskets
                                               .Include(x => x.BasketItems)
                                               .ThenInclude(x => x.Product)
                                               .FirstOrDefaultAsync(x => x.UserId == request.UserId);

                    if (userBasket != null)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);
                        if (product == null)
                        {
                            throw new CustomException("Bu ürün bulunamadı. Sistemsel problem olabilir.");
                        }
                        else
                        {
                            if ((product.Quantity < request.Quantity))
                            {
                                throw new CustomException("Bu ürün için yeterli stoğumuz yoktur.");
                            }
                        }
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
                            var quantityControlForBasket = userBasket.BasketItems[index].Quantity + request.Quantity;
                            if (product.Quantity < quantityControlForBasket)
                            {
                                throw new CustomException("Sepete eklemek istediğiniz ürün için " + request.Quantity + "  adet ekleme yapamazsınız. Stoklarımızda eklemek istediğiniz kadar ürün kalmamıştır");
                            }
                            userBasket.BasketItems[index].Quantity += request.Quantity;
                        }
                        _context.Baskets.Update(userBasket);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                    else
                    {
                        // User module hazırlamadığımız için bunun dummy oluşturulması gerekir.
                        throw new CustomException("Müşteri için önce oluşturulmalıdır.");
                    }
                }
                catch (CustomException ex)
                {
                    response.ReturnCode = ReturnCode.Warning;
                    response.ReturnMessage = ex.Message;
                }
                catch (Exception)
                {
                    //Exception'ı ekrana göndermemek gerek. Log şeklinde basılabilir.
                    response.ReturnCode = ReturnCode.Error;
                    response.ReturnMessage = "İşleminizi gerçekleştiremiyoruz. Lütfen daha sonra tekrar deneyiniz.";
                }
                return response;
            }
        }
    }
}