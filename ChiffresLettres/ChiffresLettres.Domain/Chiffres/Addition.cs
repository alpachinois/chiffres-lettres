namespace ChiffresLettres.Domain.Chiffres
{
    public record Addition(int FirstNumber, int SecondNumber) : Operation(FirstNumber, SecondNumber)
    {
        public override int GetResult() => FirstNumber + SecondNumber;
    }
}