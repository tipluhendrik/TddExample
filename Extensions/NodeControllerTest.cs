using System;
using Xunit;

namespace Extensions.Test
{
    public class NodeControllerTest
    {
        [Fact]
        public void Test_ToNodeView_With_Default_Node()
        {
            var node = new Node();

            var nodeController = new NodeController();
            var nodeView = nodeController.ToNodeView(node);

            Assert.Equal("", nodeView.Values["Name"]);
            Assert.Equal("-1", nodeView.Values["Id"]);            
            Assert.Equal(2, nodeView.Values.Count);
        }

        [Fact]
        public void Test_ToNodeView_With_Cost()
        {
            const int cost = 20;
            var node = new Node { Cost = cost };

            var nodeController = new NodeController();
            var nodeView = nodeController.ToNodeView(node);

            Assert.Equal(cost.ToString(), nodeView.Values["Cost"]);
        }
    }
}
