using System;

namespace ChiffresLettres.Domain.Chiffres
{
    public record Divide(int FirstNumber, int SecondNumber) : Operation(FirstNumber, SecondNumber)
    {
        public override int GetResult()
        {
            if (FirstNumber % SecondNumber == 0)
                return FirstNumber / SecondNumber;

            throw new InvalidOperationException($"{FirstNumber} cannot be divided integrally by {SecondNumber}");
        }
    }
}