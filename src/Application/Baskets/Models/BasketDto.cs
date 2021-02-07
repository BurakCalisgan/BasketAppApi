using System;
using System.Collections.Generic;
using BasketAppApi.Domain.Entities;

namespace BasketAppApi.Application.Baskets.Models
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItem> BasketItems { get; set; }
    }
}