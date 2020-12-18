using System;
using ConsoleApp;
using Xunit;

namespace ConsoleApp.Test
{
    public class NodeControllerTest
    {
        private readonly NodeController _nodeController;

        public NodeControllerTest()
        {
            _nodeController = new NodeController();
        }
        [Theory]
        [InlineData("A new Name")]
        [InlineData("")]
        public void GetValues_Contains_Node_Name(string name)
        {
            var node = new Node { Name = name };
          
            var values = _nodeController.GetValues(node);

            Assert.Equal(name, values["Name"]);
        }

        [Fact]
        public void GetValues_New_Node_No_Name_Output_Unknown()
        {
            var node = new Node();
          
            var values = _nodeController.GetValues(node);

            Assert.Equal("Unknown", values["Name"]);
        }
    }
}
