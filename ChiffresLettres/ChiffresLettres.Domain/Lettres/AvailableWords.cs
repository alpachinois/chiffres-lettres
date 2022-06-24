using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ChiffresLettres.Domain.Lettres
{
    public static class AvailableWords
    {
        private const string WordsPath = "Lettres\\Liste_Mots_Disponible.txt";
        public static readonly NameValueCollection AllPossibleWords;

        static AvailableWords()
        {
            
            if (!File.Exists(WordsPath))
                throw new FileNotFoundException(WordsPath);
            
            var words = File.ReadAllLines(WordsPath)
                .Where(x => x.Length <= 10)
                .Select(x => x.ToUpper())
                .Select(RemoveDiacritics)
                .Distinct();

            AllPossibleWords = new NameValueCollection();

            foreach (var word in words)
            {
                var sortedWord = string.Concat(word.OrderBy(c => c));
                AllPossibleWords.Add(sortedWord, word);
            }
        }

        private static string RemoveDiacritics(string s)
        {
            var normalizedString = s.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Copy from http://appetere.com/post/generate-all-combinations-of-a-sequence
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetCombinations(this string source) =>
            source.Aggregate(
                seed: new List<string>(),
                func: (acc, c) =>
                {
                    var acc2 = acc.SelectMany(item =>
                        new List<string> { item, c + item, item + c }).ToList();
                    acc2.Add(c.ToString());
                    return acc2;
                });
    }
}