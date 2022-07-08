using System;

namespace ChiffresLettres.Domain.Chiffres
{
    public record Multiply(int FirstNumber, int SecondNumber) : Operation(FirstNumber, SecondNumber)
    {
        public override int GetResult()
        {
            if (FirstNumber == 1 || SecondNumber == 1)
                throw new InvalidOperationException("Multiply by 1 is useless");

            return FirstNumber * SecondNumber;
        }
    }
}