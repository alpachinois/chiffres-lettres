using System.Threading;
using System.Threading.Tasks;
using ChiffresLettres.Application.Lettres;
using ChiffresLettres.Domain.Lettres;
using FluentAssertions;
using Xunit;

namespace ChiffresLettres.Application.Tests
{
    public class MotPlusLongCommandTests
    {
        private readonly IWordsService _wordsService = new WordsService();

        [Fact]
        public async Task Given_IAmPlayer_When_IStartLongestWord_Then_Return10RandomCharacters()
        {
            var command = new CreateRandomDrawCommand(5);
            var commandHandler = new CreateRandomDrawCommandHandler(_wordsService);

            var sut = await commandHandler.Handle(command, CancellationToken.None);
            sut.Length.Should().Be(10);
        }
        
        [Fact]
        public async Task Given_IAmPlayer_When_IStartLongestWord_Then_OnlyLettersAreReturned()
        {
            var command = new CreateRandomDrawCommand(5);
            var commandHandler = new CreateRandomDrawCommandHandler(_wordsService);

            var sut = await commandHandler.Handle(command, CancellationToken.None);
            foreach (var c in sut)
            {
                char.IsDigit(c).Should().BeFalse();
            }
        }
        
    }
}
