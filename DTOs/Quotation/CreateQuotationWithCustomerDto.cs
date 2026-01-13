using Optera.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DTOs.Quotation
{
    public class CreateQuotationWithCustomerDto
    {
        public CreateCustomerDto Customer { get; set; }
        public CreateQuotationDto Quotation { get; set; }
    }
}
