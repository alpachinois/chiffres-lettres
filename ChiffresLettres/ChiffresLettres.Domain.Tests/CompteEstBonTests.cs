using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using ChiffresLettres.Domain.Chiffres;

namespace ChiffresLettres.Domain.Tests
{
    public class CompteEstBonTests
    {
        [Fact]
        public void Get_Available_Numbers()
        {
            var service = new NumbersService();
            var sut = service.CreateRandomDraw(out _);
            sut.Should().HaveCount(6);
        }

        [Fact]
        public void Numbers_Must_Be_In_List()
        {
            var availableNumbers = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 25, 50, 75, 100};
            var service = new NumbersService();
            var sut = service.CreateRandomDraw(out _);
            availableNumbers.Should().Contain(sut);
        }

        [Fact]
        public void Result_Must_Between_1_To_999()
        {
            var service = new NumbersService();
            service.CreateRandomDraw(out var result);
            result.Should().BeInRange(1, 999);
        }

        [Fact]
        public void Control_Result()
        {
            var service = new NumbersService();
            var numbers = new[] { 2, 25, 4, 10, 7, 6 };
            var searchedResult = 732;

            var operations = new List<Operation>();

            var sut = service.IsCorrect(numbers, operations, searchedResult);
            sut.Should().Be(true);
        }
        
        [Fact]
        public void CannotDivide_Exception()
        {
            var divide = new Divide(3, 2);
            Action act = () => divide.GetResult();

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("3 cannot be divided integrally by 2");
        }
        
        [Fact]
        public void MultiplyIsUseless_Exception()
        {
            var multiply = new Multiply(3, 1);
            Action act = () => multiply.GetResult();

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Multiply by 1 is useless");
        }
        
        [Fact]
        public void SubstractLessThanZero_Exception()
        {
            var substract = new Substraction(2, 3);
            Action act = () => substract.GetResult();

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Substraction return negative result");
        }
    }
}