using System.Collections.Immutable;

namespace ChiffresLettres.Domain.Lettres
{
    public interface IWordsService
    {
        ImmutableArray<string> FindWords(string randomCharacters);
        char[] CreateRandomDraw(int vowelNumber);
    }
}