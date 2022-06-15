using System.Collections.Generic;

namespace ChiffresLettres.Domain.Lettres
{
    public class Node
    {
        public Node(char character, bool isCompleteWord = false)
        {
            Character = character;
            IsCompleteWord = isCompleteWord;
        }

        public Node()
        {
            
        }
        
        public char Character { get; init; }
        public Dictionary<char, Node> Children { get; private set; } = new ();
        public bool IsCompleteWord { get; set; }
    }
}