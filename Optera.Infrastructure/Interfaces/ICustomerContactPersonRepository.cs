using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Interfaces
{
    public interface ICustomerContactPersonRepository
    {
        public void AddCustomerContactPerson(ICollection<CustomerContactPerson> customerContacts);
    }
}
