using System;
using BasketAppApi.Application.Products.Commands;
using BasketAppApi.Application.Products.Models;
using MediatR;
using Moq;
using WebApi.Controllers;
using Xunit;

namespace BasketAppApi.WebApi.UnitTests.Products
{
    public class ProductApiTest
    {
        private readonly IMediator _mediator;
        public ProductApiTest()
        {
            _mediator = new Mock<IMediator>().Object;
        }

        [Fact]
        public async void CreateProduct()
        {
            ProductController productController = new ProductController(_mediator);
            Random rnd = new Random();
            ProductDto dto = new ProductDto
            {
                Name = "Test Product" + rnd.Next(1, 100),
                Quantity = rnd.Next(1, 10)
            };
            var result = await productController.Create(dto);

            Assert.NotNull(result);
        }
    }
}