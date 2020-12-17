using System;
using Xunit;

namespace Extensions
{
    public class NodeTest
    {[Fact]
        public void Test_New_Node_Has_Empty_Name()
        {
            var node = new Node();
            
            var expected = "";
            Assert.Equal(expected, node.Name);
        }
        [Fact]
        public void Test_New_Node_Has_No_Kosten()
        {
            var node = new Node();

            Assert.False(node.Cost.HasValue);
        }
        [Fact]
        public void Test_New_Node_Has_Mid_Priority()
        {
            var node = new Node();

            Assert.Equal(Priority.Mid, node.Priority);
        }

    }
}
