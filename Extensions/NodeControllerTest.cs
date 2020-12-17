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

            Assert.Equal(3, nodeView.Values.Count);

            Assert.Equal("", nodeView.Values["Name"]);
            Assert.Equal("-1", nodeView.Values["Id"]);
            Assert.Equal("Mid", nodeView.Values["Priority"]);
        }

        [Theory]
        [InlineData(0, Currency.Eur, "0 €")]
        [InlineData(20, Currency.Usd, "20 $")]
        [InlineData(100, Currency.Gbp, "100 £")]
        public void Test_ToNodeView_With_Cost(int cost, Currency currency, string expected)
        {
            var node = new Node { Currency = currency, Cost = cost};            

            var nodeController = new NodeController();
            var nodeView = nodeController.ToNodeView(node);

            Assert.Equal(expected, nodeView.Values["Cost"]);
        }

        [Theory]
        [InlineData(Priority.Low)]
        [InlineData(Priority.Mid)]
        [InlineData(Priority.High)]
        public void Test_ToNodeView_With_Set_Priority(Priority priority)
        {
            var node = new Node { Priority = priority };

            var nodeController = new NodeController();
            var nodeView = nodeController.ToNodeView(node);

            Assert.Equal(priority.ToString(), nodeView.Values["Priority"]);
        }

    }
}
