using Dapper;
using Framework.Core.Bus;
using Framework.Core.Persistence;
using Mc2.CrudTest.QueryService.Contract.DataContract;
using Mc2.CrudTest.QueryService.Contract.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.QueryService.QueryHandler
{
    public class CustomerQueryService : ICustomerQueryService
    {
        public bool CustomerExistWhitEmailAddress(string emailAddress)
        {
            using (var connection = DbConnectionFactory.GetReadModelDbConnection())
            {

                return connection.ExecuteScalar<bool>("SELECT count(1) FROM Customers WHERE EmailAddress=@EmailAddress", new { emailAddress });
            }
        }

        public IList<CustomerDto> GetCustomers()
        {
            using (var connection = DbConnectionFactory.GetReadModelDbConnection())
            {

                return connection.Query<CustomerDto>("SELECT * FROM Customers ").ToList();
            }
            
        }


    }
}
