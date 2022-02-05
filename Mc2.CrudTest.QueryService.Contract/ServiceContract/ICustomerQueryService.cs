using Mc2.CrudTest.QueryService.Contract.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.QueryService.Contract.ServiceContract
{
    public interface ICustomerQueryService
    {
        IList<CustomerDto> GetCustomers();
        bool CustomerExistWhitEmailAddress(string email);
    }
}
