using System.Collections.Generic;

namespace Extensions

{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Kosten { get; set; }
        public Priority Priority { get; set; }
    }
}