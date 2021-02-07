using System;
using System.Collections.Generic;
using BasketAppApi.Domain.Entities;

namespace BasketAppApi.Application.Baskets.Models
{
    public class BasketByUserIdDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public decimal TotalPrice { get; set; }
        public List<BasketItemModel> BasketItems { get; set; }
    }

     public class BasketItemModel
    {
        public int BasketItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}