using System;

namespace ChiffresLettres.Domain.Chiffres
{
    public record Substraction(int FirstNumber, int SecondNumber) : Operation(FirstNumber, SecondNumber)
    {
        public override int GetResult()
        {
            var result = FirstNumber - SecondNumber;
            if (result >= 0) return result;

            throw new InvalidOperationException("Substraction return negative result");
        }
    }
}