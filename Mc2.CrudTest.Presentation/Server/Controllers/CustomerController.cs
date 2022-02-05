using Framework.Core.Bus;
using Mc2.CrudTest.Application.Contract.Customer;
using Mc2.CrudTest.Presentation.Contract;
using Mc2.CrudTest.QueryService.Contract.ServiceContract;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly ICustomerQueryService _customerQueryService;
        public CustomerController(ICommandBus commandBus, ICustomerQueryService customerQueryService)
        {
            _commandBus = commandBus;
            _customerQueryService = customerQueryService;
        }

        [HttpGet("CustomerExistByEmail/{email}")]
        public ActionResult<bool> Get(string email)
        {
            var isExist = _customerQueryService.CustomerExistWhitEmailAddress(email);
            return Ok(isExist);
        } 

        [HttpPost]
        public ActionResult Post(RegisterCustomerModel model)
        {
            var command = new RegisterCustomerCommand()
            {
                BankAccountNumber = model.BankAccountNumber,
                DateOfBirth = model.DateOfBirth.Value,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber
            };
            _commandBus.Send(command);
            return Ok();
        }
    }


}
