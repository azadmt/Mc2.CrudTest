using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Shared
{
    public class EmailAddress : ValueObject
    {
        const string PATTERN = @"^(([^<>()[\]\\.,;:\s@\""]+"

               + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"

               + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"

               + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"

               + @"[a-zA-Z]{2,}))$";

        public string Value { get; private set; }

        private EmailAddress(String email)
        {
            Value = email;
        }

        public static EmailAddress Create(string email)
        {
            if (ValidateEmail(email))
            {
                return new EmailAddress(email);
            }

            throw new ArgumentException($"{email} is not valid!!!");

        }
        public static bool IsValid(string email)
        {
            return ValidateEmail(email);
        }

        private static bool ValidateEmail(string email)
        {
            var regex = new Regex(PATTERN);

            return regex.IsMatch(email);
        }
 
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
