using FluentAssertions;
using Mc2.CrudTest.Shared;
using System;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class MobileNumberTest
    {
        [Theory]
        [InlineData("+989127646102")]//Iran
        [InlineData("+66812345678")]//Philippines
        [InlineData("+61455666777")]//Australia

        public void Should_Create_MobileNumber_Whith_Valid_International_Input_Format(string input)
        {
            var result = MobileNumber.Create(input);
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData("+988727646102")]
        [InlineData("+621123s45678")]
        [InlineData("+67755666777")]
        [InlineData("+6211FFss45s678")]
        [InlineData("+677556c66777")]
        public void Should_Not_Create_MobileNumber_Whith_InValid_International_Input_Format(string input)
        {
            Action result = () => MobileNumber.Create(input);
            result.Should().Throw<ArgumentException>().WithMessage($"{input} is not a valid mobile number!!!");
        }

        [Theory]
        [InlineData("988727646102")]
        [InlineData("62112345678")]
        [InlineData("67755666777")]

        public void Should_Not_Create_MobileNumber_WhithOut_International_Symbol(string input)
        {
            Action result = () => MobileNumber.Create(input);
            result.Should().Throw<ArgumentException>().WithMessage($"{input} is not a valid mobile number!!!");
        }

        [Theory]
        [InlineData("988727646102")]
        [InlineData("62112345678")]
        [InlineData("67755666777")]

        public void MobileNumber_WhithOut_International_Symbol_Is_Not_Valid(string input)
        {
            var result =  MobileNumber.IsValid(input);
            result.Should().BeFalse();
        }

    }
}
