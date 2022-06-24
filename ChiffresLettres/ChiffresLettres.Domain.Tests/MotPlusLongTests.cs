using System;
using ChiffresLettres.Domain.Lettres;
using Xunit;
using FluentAssertions;

namespace ChiffresLettres.Domain.Tests
{
    public class MotPlusLongTests
    {
        private static readonly WordsService Service = new();
        
        [Fact]
        public void Dictionary_Not_Empty()
        {
            AvailableWords.AllPossibleWords.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void Find_Longest_Word_Test()
        {
            var randomCharacters = "ABCDEFGHIJ";

            var sut = Service.FindWords(randomCharacters);
            sut.Should().Contain("FICHAGE");
            sut.Should().Contain("DEFICHA");
            sut.Should().HaveCount(2);
        }
        
        [Fact]
        public void Find_Longest_Word_With_Repeated_Char_Test()
        {
            var randomCharacters = "NAANZZZZZZ";

            var sut = Service.FindWords(randomCharacters);
            sut.Should().Contain("NANA");
            sut.Should().HaveCount(1);
        }
        
        [Fact]
        public void Given_IAmPlayer_When_IChooseMoreThan10Vowels_Then_ExceptionRaise()
        {
            var vowelsNumber = 11;
            Action act = () => Service.CreateRandomDraw(vowelsNumber);

            act.Should().Throw<NumberVowelsMustBeLessThanTenException>()
                .WithMessage("Max number allowed : 10");
        }
    }
}