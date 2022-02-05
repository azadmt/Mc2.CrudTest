using PhoneNumbers;
using System;

namespace Mc2.CrudTest.Shared
{
    public class MobileNumber
    {
        public string Value { get; private set; }

        private MobileNumber(string number)
        {
            Value = number;
        }


        public static MobileNumber Create(string number)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var mobileNumber = phoneUtil.Parse(number, null);
                if (!phoneUtil.IsValidNumber(mobileNumber) || phoneUtil.GetNumberType(mobileNumber) != PhoneNumberType.MOBILE)
                    throw new ArgumentException($"{number} is not a valid mobile number!!!");
            }
            catch
            {
                throw new ArgumentException($"{number} is not a valid mobile number!!!");
            }

            return new MobileNumber(number);
        }

        public static bool IsValid(string number)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            var mobileNumber = phoneUtil.Parse(number, null);
            return phoneUtil.IsValidNumber(mobileNumber);
        }
    }
}
