using System;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ChiffresLettres.Domain.Lettres
{
    public static class AvailableWords
    {
        public static readonly ImmutableHashSet<string> Words;
        private const string WordsPath = "Lettres\\Liste_Mots_Disponible.txt";

        static AvailableWords()
        {
            
            if (!File.Exists(WordsPath))
                throw new FileNotFoundException(WordsPath);
            
            var words = File.ReadAllLines(WordsPath);
            Words = words
                .Where(x => x.Length <= 10)
                .Select(x => x.ToUpper())
                .Select(x => RemoveDiacritics(x))
                .Distinct()
                .ToImmutableHashSet();
        }

        private static string RemoveDiacritics(string s)
        {
            var normalizedString = s.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                var c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
}