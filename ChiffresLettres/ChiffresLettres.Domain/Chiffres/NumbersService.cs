using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiffresLettres.Domain.Chiffres
{
    public class NumbersService : INumbersService
    {
        private static readonly int[] AvailableNumbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 25, 50, 75, 100};

        public IEnumerable<int> CreateRandomDraw(out int result)
        {
            var r = new Random();
            result = r.Next(1, 999);
            return AvailableNumbers.OrderBy(x => r.Next()).Take(6);
        }

        public bool IsCorrect(int[] numbers, List<Operation> operations, int searchedResult)
        {
            return true;
        }
    }
}