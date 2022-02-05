using FluentAssertions;
using Mc2.CrudTest.Shared;
using System;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class EmaileAddressTest
    {
        [Theory]
        [InlineData("asd@asd.com")]
        [InlineData("___asd2@yah.coom")]
        [InlineData("24234wefadf@gmail.com")]
        [InlineData("231232dscsdcsdfsdv@yamail.com")]
        public void Should_Create_EmailAddress_Whith_Valid_Input(string email)
        {
            var emaileAddress = EmailAddress.Create(email);
            emaileAddress.Should().NotBeNull();
        }

        [Theory]
        [InlineData("asdasd.com")]
        [InlineData("_hgsfghyahoocom")]
        [InlineData("aaaaaa@gmailcom")]
        [InlineData("231232dadasfsdvyamail.com")]
        public void Should_Not_Create_EmailAddress_Whith_InValid_Input(string email)
        {
            Action act = () => EmailAddress.Create(email);
            act.Should().ThrowExactly<ArgumentException>()
             .WithMessage($"{email} is not valid!!!");
        }
    }
}
