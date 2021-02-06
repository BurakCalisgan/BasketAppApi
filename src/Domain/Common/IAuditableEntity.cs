using System;

namespace BasketAppApi.Domain.Common
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        string CreatedBy { get; set; }

        string UpdatedBy { get; set; }
    }
}