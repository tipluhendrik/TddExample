using System.Collections.Generic;

namespace Extensions

{
    public class Node
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; } = "";
        public int? Cost { get; set; }
        public Priority Priority { get; set; }
    }
}