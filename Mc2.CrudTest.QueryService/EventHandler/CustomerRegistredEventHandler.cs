using Dapper;
using Framework.Core.Persistence;
using MassTransit;
using Mc2.CrudTest.Domain.Contract;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.QueryService.EventHandler
{
    public class CustomerRegistredEventHandler : IConsumer<CustomerRegistredEvent>
    {
        public async Task Consume(ConsumeContext<CustomerRegistredEvent> context)
        {
            SqlMapper.AddTypeMap(typeof(DateTime), System.Data.DbType.DateTime2);
            string sql = "INSERT INTO Customers  Values (@Id,@FirstName,@LastName,@EmailAddress,@BankAccountNumber,@PhoneNumber,@DateOfBirth,@HasConfilict);";
            using (var connection = DbConnectionFactory.GetReadModelDbConnection())
            {
                //Domain Unique Constraints With CQRS/ES https://groups.google.com/g/dddcqrs/c/aUltOB2a-3Y/m/0p0PQVNFONQJ
                //I Prefer check EmailAddressDuplication in client side and Handle RegisterCustomerCommand
                //when emailAddressExist in the ReadModel set true customer HasConfilict and notify system admin 
                var emailAddressExist = connection.ExecuteScalar<bool>("SELECT count(1) FROM Customers WHERE EmailAddress=@EmailAddress", new { context.Message.EmailAddress });
                await connection.ExecuteAsync(sql,
                new
                {
                    Id = context.Message.Id,
                    FirstName = context.Message.FirstName,
                    LastName = context.Message.LastName,
                    EmailAddress = context.Message.EmailAddress,
                    BankAccountNumber = context.Message.BankAccountNumber,
                    PhoneNumber = context.Message.PhoneNumber,
                    DateOfBirth = context.Message.DateOfBirth,
                    HasConfilict = emailAddressExist
                });
    

            }
        }

    }
}
