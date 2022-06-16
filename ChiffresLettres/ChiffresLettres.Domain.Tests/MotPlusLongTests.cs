using System.Linq;
using ChiffresLettres.Domain.Lettres;
using Xunit;
using FluentAssertions;

namespace ChiffresLettres.Domain.Tests
{
    public class MotPlusLongTests
    {
        [Fact]
        public void Dictionary_Not_Empty()
        {
            AvailableWords.Words.Should().NotBeEmpty();
        }
        
        [Fact]
        public void Find_Longest_Word_Test()
        {
            var randomCharacters = "ABCDEFGHIJ";

            var service = new WordsService();

            var sut = service.FindWords(randomCharacters).Any(x => x == "FICHAGE");
            sut.Should().BeTrue();
        }

        [Fact]
        public void Check_Existing_Word_Test()
        {
            var service = new WordsService();

            var sut = service.WordExist("ABCDEFGHIJ");
            sut.Should().BeFalse();

            sut = service.WordExist("FICHAGE");
            sut.Should().BeTrue();
        }
    }
}