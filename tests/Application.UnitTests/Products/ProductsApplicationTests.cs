using System;
using BasketAppApi.Application.Products.Commands;
using BasketAppApi.Application.UnitTests.Common;
using MediatR;
using Moq;
using Xunit;

namespace BasketAppApi.Application.UnitTests.Products
{
    public class ProductsApplicationTests : TestBase
    {
        //For Mock
        private readonly IMediator _mediator;
        public ProductsApplicationTests()
        {
            //Mock
            _mediator = new Mock<IMediator>().Object;
        }

        //Mock Test Function
        [Fact]
        public async void CreateProductTestForMock()
        {
            Random rnd = new Random();
            CreateProductCommand command = new CreateProductCommand
            {
                Product = new Application.Products.Models.ProductDto
                {
                    Name = "Test Product"
                    + rnd.Next(1, 100),
                    Quantity = rnd.Next(1, 10)
                }
            };
            var response = await _mediator.Send(command);

            Assert.NotNull(response);
        }


        //Test Function with Context
        [Fact]
        public async void CreateProductTest()
        {
            Random rnd = new Random();
            CreateProductCommand command = new CreateProductCommand
            {
                Product = new Application.Products.Models.ProductDto
                {
                    Name = "Test Product"
                    + rnd.Next(1, 100),
                    Quantity = rnd.Next(1, 10)
                }
            };
            var result = await SendAsync(command);

            Assert.Equal(1,result);
        }
    }
}
