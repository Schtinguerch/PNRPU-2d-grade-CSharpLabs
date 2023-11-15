using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using LaboratoryWorkNo12;
using Task_2_DynamicTypeIdentification;
using Xunit;

namespace Tests
{
    public class TestMyOwnLinkedList
    {
        private (string[], MyOwnLinkedList<string>) GetFilledLinkedList()
        {
            var words = new[] {"What", "You", "Are", "Going", "To", "Do"};
            var list = new MyOwnLinkedList<string>();

            foreach (var word in words)
            {
                list.Add(word);
            }

            return (words, list);
        }
        
        [Fact]
        public void TestSequence()
        {
            (var words, var list) = GetFilledLinkedList();
            Assert.True(list.SequenceEqual(words));
        }

        [Fact]
        public void TestIndexer()
        {
            (var words, var list) = GetFilledLinkedList();
            Assert.Equal(words.Length, list.Count);

            var testValue = "We All";
            Assert.Equal(words[1], list[1]);

            list[1] = testValue;
            Assert.Equal(testValue, list[1]);
            
            Assert.Equal(words[0], list.First.Value);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var unexistingItem = list[-1];
            });

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var unexistingItem = list[list.Count];
            });
        }
        
        [Fact]
        public void TestSearching()
        {
            (var words, var list) = GetFilledLinkedList();

            var existingWord = words[3];
            var unexistingWord = "WowWowWowWow";
            
            Assert.True(list.Contains(existingWord));
            Assert.False(list.Contains(unexistingWord));
        }

        [Fact]
        public void TestArrayCopy()
        {
            (var words, var list) = GetFilledLinkedList();
            var testArray = new string[words.Length];

            list.CopyTo(testArray, 0);
        }

        [Fact]
        public void TestRemoveItem()
        {
            (var words, var list) = GetFilledLinkedList();

            var deleteIndex = 3;
            var deletedItem = list[deleteIndex];
            
            list.Remove(deletedItem);
            Assert.False(list.Contains(deletedItem));

            list.Remove(words[0]);
            Assert.False(list.Contains(words[0]));
        }

        [Fact]
        public void TestCount()
        {
            (var words, var list) = GetFilledLinkedList();
            Assert.Equal(words.Length, list.Count);
        }

        [Fact]
        public void TestClearing()
        {
            (var words, var list) = GetFilledLinkedList();
            
            list.Clear();
            Assert.True(list.Count == 0);
        }

        [Fact]
        public void TestCopying()
        {
            (var words, var list) = GetFilledLinkedList();

            var shallowCopied = list.ShallowCopy() as MyOwnLinkedList<string>;
            Assert.True(list.SequenceEqual(shallowCopied));

            var cloned = list.Clone() as MyOwnLinkedList<string>;
            Assert.True(list.SequenceEqual(cloned));
        }

        [Fact]
        public void GetFirst()
        {
            (var words, var list) = GetFilledLinkedList();

            var firstNode = list.First;
            var firstSource = words[0];
            
            Assert.Equal(firstSource, firstNode.Value);
        }

        [Fact]
        public void SetValueByIndex()
        {
            (var words, var list) = GetFilledLinkedList();

            var newWord = "yes";
            words[2] = newWord;
            list[2] = newWord;
            
            Assert.Equal(words, list);
        }

        [Fact]
        public void ClearList()
        {
            (var words, var list) = GetFilledLinkedList();
            list.Clear();
            
            Assert.Equal(null, list.First);
            Assert.Equal(null, list.Last);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Copying()
        {
            (var words, var list) = GetFilledLinkedList();
            list.CopyTo(words, 0);
        }

        [Fact]
        public void SwallowCopy()
        {
            var list = new MyOwnLinkedList<TrainCar>()
            {
                new Locomotive(100, 100, 100, 100),
                new Locomotive(200, 200, 200, 200),
                new Locomotive(300, 300, 200, 300),
            };

            var copied = list.ShallowCopy() as MyOwnLinkedList<TrainCar>;
            Assert.Equal(list.Count, copied.Count);
            
            for (var i = 0; i < list.Count; i += 1)
            {
                Assert.Same(list[i], copied[i]);
            }
        }

        [Fact]
        public void Clone()
        {
            var list = new MyOwnLinkedList<TrainCar>()
            {
                new Locomotive(100, 100, 100, 100),
                new Locomotive(200, 200, 200, 200),
                new Locomotive(300, 300, 200, 300),
            };

            var cloned = list.Clone() as MyOwnLinkedList<TrainCar>;
            Assert.Equal(list.Count, cloned.Count);

            for (var i = 0; i < list.Count; i += 1)
            {
                Assert.NotSame(list[i], cloned[i]);

                var sameData = list[i].CompareTo(cloned[i]);
                Assert.Equal(0, sameData);
            }
        }

        [Fact]
        public void Removing()
        {
            (var words, var list) = GetFilledLinkedList();
            
            list.Remove(words[0]);
            Assert.False(list.Contains(words[0]));
        }

        [Fact]
        public void RemovingUnexisting()
        {
            (var words, var list) = GetFilledLinkedList();

            var cleared = list.Remove("a.suthoaeurl,.;husaeous");
            Assert.False(cleared);
        }
    }
}