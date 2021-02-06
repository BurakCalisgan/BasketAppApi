using BasketAppApi.Domain.Common;

namespace BasketAppApi.Domain.Entities
{
    public class Basket : AuditableEntity<int>
    {
        public string UserId { get; set; }
    }
}