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
    }
}