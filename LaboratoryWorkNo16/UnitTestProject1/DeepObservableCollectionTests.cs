using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WpfFileWorking.ViewModels;
using System.Collections.Specialized;
using Xunit;

namespace UnitTestProject1
{
    public class DeepObservableCollectionTests
    {
        [Fact]
        public void Initialization()
        {
            var standardList = new List<int>() { 1, 2, 3, 4, 5 };
            var deepObservableCollection = new DeepObservableCollection<int>(standardList);

            Assert.True(standardList.SequenceEqual(deepObservableCollection));
        }

        [Fact]
        public void EmptyList()
        {
            var emptyCollection = new DeepObservableCollection<int>();
            Assert.Empty(emptyCollection);
        }

        [Fact]
        public void InitializeByEmptyList()
        {
            List<int> emptyList = null;
            var deepObservableCollection = new DeepObservableCollection<int>(emptyList);

            Assert.Empty(deepObservableCollection);
        }

        [Fact]
        public void AddElement()
        {
            var stardardCollection = TestPool.StandardList;
            var deepObservableCollection = TestPool.DeepObservableList;
            var newWord = "Magique";

            stardardCollection.Add(newWord);
            deepObservableCollection.Add(newWord);

            Assert.True(stardardCollection.SequenceEqual(deepObservableCollection));
        }

        [Fact]
        public void InsertElement()
        {
            var stardardCollection = TestPool.StandardList;
            var deepObservableCollection = TestPool.DeepObservableList;
            var newWord = "Magique";

            stardardCollection.Insert(0, newWord);
            deepObservableCollection.Insert(0, newWord);

            Assert.True(stardardCollection.SequenceEqual(deepObservableCollection));
        }

        [Fact]
        public void RemoveElementByIndex()
        {
            var stardardCollection = TestPool.StandardList;
            var deepObservableCollection = TestPool.DeepObservableList;

            stardardCollection.RemoveAt(1);
            deepObservableCollection.RemoveAt(1);

            Assert.True(stardardCollection.SequenceEqual(deepObservableCollection));
        }

        [Fact]
        public void InitializeByObservables()
        {
            var deepObservableCollection = new DeepObservableCollection<ObservableString>();

            deepObservableCollection.Add(new ObservableString("Dolores quos velit quia."));
            Assert.True(deepObservableCollection.Count == 1);

            deepObservableCollection.Add(new ObservableString("Aut modi ipsa vel corporis possimus earum non quo."));
            Assert.True(deepObservableCollection.Count == 2);

            deepObservableCollection.Add(new ObservableString("Quaerat quod voluptatem consequuntur et blanditiis rerum."));
            Assert.True(deepObservableCollection.Count == 3);
        }

        [Fact]
        public void RemoveObservables()
        {
            var deepObservableCollection = TestPool.DeepObservableOfObservables;
            var first = deepObservableCollection.First();

            deepObservableCollection.RemoveAt(0);

            Assert.False(deepObservableCollection.First().Equals(first));
        }

        [Fact]
        public void ChangeSimpleValue()
        {
            var deepObservableCollection = TestPool.DeepObservableList;

            var oldValue = deepObservableCollection[2];
            var newValue = "yaeoushnaeourld";

            deepObservableCollection[2] = newValue;
            Assert.False(deepObservableCollection[2] == oldValue);
            
        }

        [Fact]
        public void ChangeObservableValue()
        {
            var deepObservableCollection = TestPool.DeepObservableOfObservables;

            var oldValue = deepObservableCollection[0];
            var newValue = new ObservableString("hello");

            deepObservableCollection[0] = newValue;
            Assert.False(deepObservableCollection[0].Equals(oldValue));
        }

        [Fact]
        public void ChangePropertyOfObservable()
        {
            var deepObservableCollection = TestPool.DeepObservableOfObservables;

            var oldString = deepObservableCollection[0].Value;
            var newString = "hello";

            deepObservableCollection[0].Value = newString;
            Assert.False(deepObservableCollection[0].Value == oldString);
        }

        [Fact]
        public void EmptyObservableString()
        {
            var empty = new ObservableString();
            Assert.Equal(string.Empty, empty.Value);
        }
    }
}
