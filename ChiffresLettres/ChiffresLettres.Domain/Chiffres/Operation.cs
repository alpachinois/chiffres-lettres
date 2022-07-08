namespace ChiffresLettres.Domain.Chiffres
{
    public abstract record Operation(int FirstNumber, int SecondNumber)
    {
        public abstract int GetResult();
    }
}