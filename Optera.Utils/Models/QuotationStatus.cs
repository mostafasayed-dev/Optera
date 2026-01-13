using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Utils.Models
{
    public enum QuotationStatus
    {
        Draft,
        Submitted,
        UnderReview,
        ApprovedBySalesCoordinator,
        RejectedBySalesCoordinator,
        ApprovedBySalesExecutive,
        ApprovedByCEO,
        RejectedByCEO,
        Issued,
    }
}
