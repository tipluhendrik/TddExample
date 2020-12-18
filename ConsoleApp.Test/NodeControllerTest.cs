using System;
using ConsoleApp;
using Xunit;

namespace ConsoleApp.Test
{
    public class NodeControllerTest
    {
        [Fact]
        public void GetValues_Contains_Node_Name()
        {
            var name = "A new Name";
            var node = new Node { Name = name };

            var nodeController = new NodeController();
            var values = nodeController.GetValues(node);

            Assert.Equal(name, values["Name"]);
        }
    }
}
