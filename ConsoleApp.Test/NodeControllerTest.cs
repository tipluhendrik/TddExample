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
          
            var values = _nodeController.GetNode(node);

            Assert.Equal(name, values["Name"]);
        }

        [Fact]
        public void GetValues_New_Node_No_Name_Output_Unknown()
        {
            var node = new Node();
          
            var values = _nodeController.GetNode(node);

            Assert.Equal("Unknown", values["Name"]);
        }

        [Theory]
        [InlineData(Priority.Low)]
        [InlineData(Priority.Mid)]
        [InlineData(Priority.High)]
        public void GetValues_Contains_Node_Priority(Priority priority)
        {
            var node = new Node{ Priority = priority };

            var values = _nodeController.GetNode(node);

            Assert.Equal(priority.ToString(), values["Priority"]);
        }

        [Fact]
        public void GetValues_Empty_Node_Has_Priority_Mid()
        {
            var node = new Node();
            var values = _nodeController.GetNode(node);

            Assert.Equal(Priority.Mid.ToString(), values["Priority"]);
        }
    }
}
