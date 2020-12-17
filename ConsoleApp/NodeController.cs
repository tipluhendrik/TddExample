using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class NodeController
    {
        public IDictionary<string,string> GetValues(Node node)
        {
            var values = new Dictionary<string, string>();
            values["Name"] = node.Name;

            return values;
        }
    }
}