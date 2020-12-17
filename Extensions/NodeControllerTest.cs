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

            Assert.Equal(2, nodeView.Values.Count);

            Assert.Equal("", nodeView.Values["Name"]);
            Assert.Equal("Mid", nodeView.Values["Priority"]);
        }

        [Theory]
        [InlineData(0, Currency.EUR, "0 EUR")]
        [InlineData(20, Currency.USD, "20 USD")]
        [InlineData(100, Currency.GBP, "100 GBP")]
        public void Test_ToNodeView_With_Cost(int cost, Currency currency, string expected)
        {
            var node = new Node { Currency = currency, Cost = cost};            

            var nodeController = new NodeController();
            var nodeView = nodeController.ToNodeView(node);

            Assert.Equal(expected, nodeView.Values["Cost"]);
            Assert.False(nodeView.Values.ContainsKey("Income"));
        }
        [Theory]
        [InlineData(-200, Currency.EUR, "0 EUR", "200 EUR")]
        [InlineData(-100, Currency.USD, "0 USD", "100 USD")]
        [InlineData(-20, Currency.GBP, "0 GBP", "20 GBP")]
        public void Test_ToNodeView_With_Negative_Cost_Has_Income(int cost, Currency currency, string expectedCost, string expectedIncome)
        {
            var node = new Node { Currency = currency, Cost = cost};            

            var nodeController = new NodeController();
            var nodeView = nodeController.ToNodeView(node);

            Assert.Equal(expectedCost, nodeView.Values["Cost"]);
            Assert.Equal(expectedIncome, nodeView.Values["Income"]);
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

        [Theory]
        [InlineData(Currency.USD, 10, 10, 0)]
        [InlineData(Currency.EUR, 20, 20, 0)]
        [InlineData(Currency.GBP, 30, 30, 0)]
        public void Test_Calculate_Sum_Income_Cost_Total(Currency currency, int expectedIncome, int expectedExpense, int expectedTotal)
        {
            var nodeList = new [] {
                new Node{ Cost = 10, Currency = Currency.USD },
                new Node{ Cost = -10, Currency = Currency.USD},
                new Node{ Cost = 20, Currency = Currency.EUR},
                new Node{ Cost = -20, Currency = Currency.EUR },
                new Node{ Cost = 30, Currency = Currency.GBP },
                new Node{ Cost = -30, Currency = Currency.GBP},
            };
            var nodeController = new NodeController();
            Bilanz bilanz = nodeController.GetBilanz(nodeList, currency);

            Assert.Equal(expectedIncome, bilanz.Income);
            Assert.Equal(expectedExpense, bilanz.Expenses);
            Assert.Equal(expectedTotal, bilanz.Total);

        }
    }
}
