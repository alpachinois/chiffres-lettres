using System;
using System.Collections.Immutable;
using System.Linq;

namespace ChiffresLettres.Domain.Lettres
{
    public class WordsService : IWordsService
    {
        private static readonly Random Random = new();
        private const string ConsonantPool = "BCDFGHJKLMNPQRSTVWXZ";
        private const string VowelPool = "AEIOUY";

        public ImmutableArray<string> FindWords(string randomCharacters)
        {
            for (var i = 0; i <= 9; i++)
            {
                var possibleWords = AvailableWords.Words.Where(x => x.Length == randomCharacters.Length - i);

                var allWords = possibleWords.Where(word => 
                    randomCharacters.Intersect(word.ToCharArray()).Count() == word.ToCharArray().Length);

                var enumerable = allWords as string[] ?? allWords.ToArray();
                if (enumerable.Length > 0)
                    return enumerable.ToImmutableArray();
                
            }

            return ImmutableArray<string>.Empty;
        }

        public char[] CreateRandomDraw(int vowelNumber)
        {
            var consonants = Enumerable.Range(0, 10 - vowelNumber)
                .Select(x => ConsonantPool[Random.Next(0, ConsonantPool.Length)]).ToArray();

            var vowels = Enumerable.Range(0, 10 - vowelNumber)
                .Select(x => VowelPool[Random.Next(0, VowelPool.Length)]).ToArray();

            var result = new char[10];
            consonants.CopyTo(result, 0);
            vowels.CopyTo(result, consonants.Length);
            
            return result;
        }

        public bool WordExist(string word) => AvailableWords.Words.Contains(word);
    }
}