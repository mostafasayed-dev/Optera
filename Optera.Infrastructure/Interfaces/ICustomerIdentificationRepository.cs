using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface ICustomerIdentificationRepository
    {
        public void AddCustomerIdentifications(ICollection<CustomerIdentification> customerIdentifications);
    }
}
