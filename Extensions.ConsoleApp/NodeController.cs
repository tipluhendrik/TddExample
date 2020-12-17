using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public class NodeController
    {
        public NodeView ToNodeView(Node node)
        {
            var values = new Dictionary<string, string>();

            values["Name"] = node.Name;
            if (node.Cost.HasValue && node.Cost.Value >= 0)
            {
                values["Cost"] = BuildCostString(node.Cost.Value, node.Currency);
            }
            if (node.Cost.HasValue && node.Cost < 0)
            {
                values["Cost"] = BuildCostString(0, node.Currency);
                values["Income"] = BuildCostString(-node.Cost.Value, node.Currency);

            }
            values["Priority"] = node.Priority.ToString();

            return new NodeView(values);
        }

        internal object GetBilanz(IEnumerable<Node> nodes, object eur)
        {
            throw new NotImplementedException();
        }

        private string BuildCostString(int cost, Currency currency)
        {
            return $"{cost} {currency.ToString()}";
        }

        public Bilanz GetBilanz(IEnumerable<Node> nodeList, Currency currency)
        {
            var costs = nodeList.Where(node => node.Cost.HasValue && node.Currency == currency).Select(node => node.Cost.Value);
            
            var income = costs.Where(cost => cost < 0).Sum(cost => -cost);
            var expenseSum = costs.Where(cost => cost > 0).Sum();
    	    var total = income - expenseSum;

            return new Bilanz{Expenses = expenseSum, Total = total, Income = income};

        }
    }
}