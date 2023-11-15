using System;
using LaboratoryWorkNo12;
using Xunit;

namespace Tests
{
    public class TestNode
    {
        [Fact]
        public void TestGetSetValue()
        {
            var testValue = "Test Value";
            var node = new Node<string>(testValue);
            
            Assert.Equal(testValue, node.Value);

            var changedTastValue = "Some other value";
            node.Value = changedTastValue;
            
            Assert.Equal(changedTastValue, node.Value);
        }

        [Fact]
        public void TestInsertion()
        {
            var texts = new[] {"Hello", "Hola", "Bonjour", "Privet"};
            var node = new Node<string>("What to say");
            
            Assert.Equal(node, node.Last);

            var lastNode = node;
            foreach (var text in texts)
            {
                var newNode = new Node<string>(text);
                lastNode.Next = newNode;

                lastNode = newNode;
            }
            
            Assert.Equal(lastNode, node.Last);
        }

        [Fact]
        public void TestLastValue()
        {
            var nodeA = new Node<int>(523);
            var nodeB = new Node<int>(-342);
            var nodeC = new Node<int>(9);

            nodeA.Next = nodeB;
            nodeB.Next = nodeC;

            var expected = nodeC;
            var actual = nodeA.Last;
            
            Assert.Equal(expected, actual);
        }
    }
}