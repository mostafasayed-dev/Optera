using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Models
{
    public class Quotation : BaseModel
    {
        public string? Code { get; set; }
        public long CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public int? NumberOfBranches { get; set; }
        public bool PermissionRequired { get; set; } = false;
        public DateTime EffectiveDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string? InChargePersonName { get; set; }
        public long? InChargePersonPositionId { get; set; }
        public virtual CategoryItem? InChargePersonPosition { get; set; }
        public string? InChargePersonPhone1 { get; set; }
        public string? InChargePersonPhone2 { get; set; }
        public string? InChargePersonEmail { get; set; }
        public long? PaymentTermId { get; set; }
        public virtual CategoryItem? PaymentTerm { get; set; }
        public long? ValidityPeriodId { get; set; }
        public virtual CategoryItem? ValidityPeriod { get; set; }
        public long? PriceNoteId { get; set; }
        public virtual CategoryItem? PriceNote { get; set; }
        public string? Document { get; set; }
        public required long EmployeeId { get; set; }
        public required Employee Employee { get; set; }
    }
}
