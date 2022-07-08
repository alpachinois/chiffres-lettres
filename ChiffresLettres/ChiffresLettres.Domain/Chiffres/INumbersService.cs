using System.Collections.Generic;

namespace ChiffresLettres.Domain.Chiffres
{
    public interface INumbersService
    {
        IEnumerable<int> CreateRandomDraw(out int result);
        bool IsCorrect(int[] numbers, List<Operation> operations, int searchedResult);
    }
}