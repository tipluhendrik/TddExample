using System;
using ConsoleApp;
using Xunit;

namespace ConsoleApp.Test
{
    public class NodeControllerTest
    {
        [Fact]
        public void Test_GetValues_With_Name()
        {
            var name = "A new Name";
            var node = new Node { Name = name };

            var nodeController = new NodeController();
            var values = nodeController.GetValues(node);

            Assert.Equal("", values["Name"]);
        }
    }
}
