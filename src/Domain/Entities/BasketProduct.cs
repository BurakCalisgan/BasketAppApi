using BasketAppApi.Domain.Common;

namespace BasketAppApi.Domain.Entities
{
    public class BasketProduct : AuditableEntity<int>
    {
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}