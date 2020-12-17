using System.Collections.Generic;

namespace Extensions

{
    public class Node
    {
        public int Id;
        public string Name;
        public IEnumerable<Extension> Extensions;
    }
}