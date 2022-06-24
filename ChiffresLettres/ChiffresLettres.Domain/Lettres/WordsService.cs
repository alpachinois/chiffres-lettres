using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ChiffresLettres.Domain.Lettres
{
    public record WordsService : IWordsService
    {
        private static readonly Random Random = new();
        private const string ConsonantPool = "BCDFGHJKLMNPQRSTVWXZ";
        private const string VowelPool = "AEIOUY";

        public ImmutableArray<string> FindWords(string randomCharacters)
        {
            var words = new List<string>();

            var combinaisons = randomCharacters
                .GetCombinations()
                .OrderByDescending(x => x.Length);
            
            foreach (var keyToTest in combinaisons)
            {
                var results = AvailableWords.AllPossibleWords[keyToTest];
                if (!string.IsNullOrEmpty(results))
                {
                    if (keyToTest.Length < words.FirstOrDefault()?.Length)
                        break;
                    
                    var values = results.Split(',');
                    words.AddRange(values);
                }
            }

            return words.ToImmutableArray();
        }
        
        public char[] CreateRandomDraw(int vowelNumber)
        {
            if (vowelNumber > 10)
                throw new NumberVowelsMustBeLessThanTenException("Max number allowed : 10");
            
            var consonants = Enumerable.Range(0, 10 - vowelNumber)
                .Select(x => ConsonantPool[Random.Next(0, ConsonantPool.Length)]).ToArray();

            var vowels = Enumerable.Range(0, vowelNumber)
                .Select(x => VowelPool[Random.Next(0, VowelPool.Length)]).ToArray();

            var result = new char[10];
            consonants.CopyTo(result, 0);
            vowels.CopyTo(result, consonants.Length);
            
            return result;
        }

        public bool IsVowel(char c) => VowelPool.Contains(c);
    }
}