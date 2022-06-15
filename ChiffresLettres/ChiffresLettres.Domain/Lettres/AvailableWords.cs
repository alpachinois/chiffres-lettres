using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace ChiffresLettres.Domain.Lettres
{
    public static class AvailableWords
    {
        public static ImmutableArray<string> Words;
        private const string WordsPath = "Lettres\\Liste_Mots_Disponible.txt";

        static AvailableWords()
        {
            
            if (!File.Exists(WordsPath))
                throw new FileNotFoundException(WordsPath);
            
            var words = File.ReadAllLines(WordsPath);
            Words = words.Select(x => x.ToUpper()).ToImmutableArray();
        }

        // public static ImmutableArray<string> GetLongestWords(char randomChar)
        // {
        //     
        // }
    }
}