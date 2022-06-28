using System.Collections.Generic;

namespace ChiffresLettres.Domain.Chiffres
{
    public interface INumbersService
    {
        IEnumerable<int> CreateRandomDraw(out int result);
    }
}