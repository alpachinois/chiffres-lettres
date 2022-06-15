using System.Collections.Generic;

namespace ChiffresLettres.Domain.Lettres
{
    public class NAirTree : ITree
    {
        public Node Head { get; set; } = new Node('\0');
        public Node Current { get; set; }

        public NAirTree()
        {
            foreach (var word in AvailableWords.Words)
            {
                Current = Head;
                AddWord(word);
            }
        }
        
        public void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                Current.IsCompleteWord = true;
                return;
            }

            char character = word[0];

            if (Current.Children.TryGetValue(character, out var node))
                Current = node;
            else
            {
                var newNode = new Node(character, false);
                Current.Children.Add(character, newNode);
                Current = Current.Children[character];
            }

            var newWord = word.Remove(0, 1);
            AddWord(newWord);
        }

        public bool FindWord(string searchedWord)
        {
            throw new System.NotImplementedException();
        }
    }
}