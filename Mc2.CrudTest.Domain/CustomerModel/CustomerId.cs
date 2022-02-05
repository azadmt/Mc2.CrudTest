using System;

namespace Mc2.CrudTest.Domain
{
    public class CustomerId
    {
        public CustomerId(string firstName,string lastName, DateTime dateOfBirth)
        {   
            //it's not unique? maybe a customer exist whit same name and  birthdate
            DbId = $"{firstName}_{lastName}_{dateOfBirth.Date.Ticks}";
        }

        public string DbId { get; private set; }
    }
}
