namespace ChiffresLettres.Domain.Lettres
{
    public interface ITree
    {
        Node Head { get; set; }
        Node Current { get; set; }

        void AddWord(string word);
        bool FindWord(string searchedWord);
    }
}