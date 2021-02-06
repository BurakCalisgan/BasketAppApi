using System;

namespace BasketAppApi.Domain.Common
{
    public class AuditableEntity<T> : IAuditableEntity
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}