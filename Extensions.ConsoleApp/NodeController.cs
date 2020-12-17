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
                values["Cost"] = BuildCostString(node);
            }
            values["Priority"] = node.Priority.ToString();

            return new NodeView(values);
        }
        private string BuildCostString(Node node)
        {
            var symbol = "";
            
            if(node.Currency == Currency.Eur)
            {
                symbol = "€";
            }

            if(node.Currency == Currency.Usd)
            {
                symbol = "$";
            }   

            if(node.Currency == Currency.Gbp)
            {
                symbol = "£";
            }

            return $"{node.Cost} {symbol}";
        }
    }
}