using Optera.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Quotation
{
    public class GetQuotationDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public int? NumberOfBranches { get; set; }
        public bool PermissionRequired { get; set; } = false;
        public DateTime EffectiveDate { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public string? InChargePersonName { get; set; }
        public long? InChargePersonPositionId { get; set; }
        public string? InChargePersonPhone1 { get; set; }
        public string? InChargePersonPhone2 { get; set; }
        public string? InChargePersonEmail { get; set; }
        public long? PaymentTermId { get; set; }
        public long? ValidityPeriodId { get; set; }
        public long? PriceNoteId { get; set; }
        public string? Document { get; set; }
        public long EmployeeId { get; set; }
        public string Status { get; set; }

        public GetCustomerDto Customer { get; set; }
    }
}
