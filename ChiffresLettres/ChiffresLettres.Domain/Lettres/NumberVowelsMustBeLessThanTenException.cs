using ChiffresLettres.Domain.SeedWork;

namespace ChiffresLettres.Domain.Lettres
{
    public class NumberVowelsMustBeLessThanTenException : DomainExceptionBase
    {
        public NumberVowelsMustBeLessThanTenException(string message) : base(message)
        {
        }
    }
}