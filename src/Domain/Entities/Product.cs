using BasketAppApi.Domain.Common;

namespace BasketAppApi.Domain.Entities
{
    public class Product : AuditableEntity<int>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}