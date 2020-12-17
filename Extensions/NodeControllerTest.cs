using System;
using Xunit;

namespace Extensions.Test
{
    public class NodeControllerTest
    {
        [Fact]
        public void GetNode()
        {
            var node = new Node { Id = 0, Name = "Name_0" };

            var nodeController = new NodeController();

            var nodeView = nodeController.ToNodeView(node);

            Assert.Equal(node.Name, nodeView.Values["Name"]);
            Assert.Equal(node.Id.ToString(), nodeView.Values["Id"]);
            Assert.Equal(2, nodeView.Values.Count);
        }

    }
}
