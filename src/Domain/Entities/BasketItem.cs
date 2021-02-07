using BasketAppApi.Domain.Common;

namespace BasketAppApi.Domain.Entities
{
    public class BasketItem : AuditableEntity<int>
    {
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}