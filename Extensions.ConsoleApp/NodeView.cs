using System.Collections.Generic;

namespace Extensions
{
    public class NodeView
    {
        public IDictionary<string, string> Values { get; }
        public NodeView(IDictionary<string, string> values)
        {
            this.Values = values;
        }
    }
}