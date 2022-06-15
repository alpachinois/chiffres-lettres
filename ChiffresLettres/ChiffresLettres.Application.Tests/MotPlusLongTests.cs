using System.Threading;
using System.Threading.Tasks;
using ChiffresLettres.Application.Lettres;
using FluentAssertions;
using Xunit;

namespace ChiffresLettres.Application.Tests
{
    public class MotPlusLongTests
    {
        [Fact]
        public async Task Given_IAmPlayer_When_IStartLongestWord_Then_Return9RandomCharacters()
        {
            var command = new CreateRandomDrawCommand();
            var commandHandler = new CreateRandomDrawCommandHandler();

            var sut = await commandHandler.Handle(command, CancellationToken.None);
            sut.Length.Should().Be(9);
        }
        
        [Fact]
        public async Task Given_IAmPlayer_When_IStartLongestWord_Then_OnlyLettersAreReturned()
        {
            var command = new CreateRandomDrawCommand();
            var commandHandler = new CreateRandomDrawCommandHandler();

            var sut = await commandHandler.Handle(command, CancellationToken.None);
            foreach (var c in sut)
            {
                char.IsDigit(c).Should().BeFalse();
            }
        }
    }
}
