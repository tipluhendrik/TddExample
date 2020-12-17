using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public class NodeController
    {
        public NodeView ToNodeView(Node node)
        {
            var values = new Dictionary<string, string>();
            
            values["Id"] = node.Id.ToString();
            values["Name"] = node.Name;
            if (node.Cost.HasValue)
            {
                values["Cost"] = node.Cost.Value.ToString();
            }

            return new NodeView(values);
        }
    }
}