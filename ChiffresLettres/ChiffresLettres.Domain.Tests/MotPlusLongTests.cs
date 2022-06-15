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
        public void Search_Longest_Word_Test()
        {
            var tree = new NAirTree();
            tree.Current.Should().NotBeNull();
        }
    }
}