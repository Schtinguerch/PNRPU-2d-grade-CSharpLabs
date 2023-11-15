using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WpfFileWorking.ViewModels;
using System.Collections.Specialized;
using Xunit;

namespace UnitTestProject1
{
    public class ListWrapperTests
    {
        private void CheckSequence(List<string> standard, ListWrapper wrapper)
        {
            Assert.True(standard.SequenceEqual(wrapper.ObservableList.Select(os => os.Value)));
        }

        [Fact]
        public void Initialization()
        {
            var list = TestPool.StandardList;
            var wrapper = new ListWrapper(list);

            CheckSequence(list, wrapper);
        }

        [Fact]
        public void AddItem()
        {
            var list = TestPool.StandardList;
            var wrapper = new ListWrapper(list);

            wrapper.ObservableList.Add(new ObservableString("test"));
            CheckSequence(list, wrapper);
        }

        [Fact]
        public void RemoveItem()
        {
            var list = TestPool.StandardList;
            var wrapper = new ListWrapper(list);

            wrapper.ObservableList.RemoveAt(0);
            CheckSequence(list, wrapper);
        }

        [Fact]
        public void ChangeWholeObservable()
        {
            var list = TestPool.StandardList;
            var wrapper = new ListWrapper(list);

            var oldValue = wrapper.ObservableList[0];
            var newValue = new ObservableString("test");

            wrapper.ObservableList[0] = newValue;

            CheckSequence(list, wrapper);
            Assert.DoesNotContain(oldValue, wrapper.ObservableList);
        }

        [Fact]
        public void ChangePropertyOfObservable()
        {
            var list = TestPool.StandardList;
            var wrapper = new ListWrapper(list);

            var oldValue = wrapper.ObservableList[2].Value;
            var newValue = "hello";

            wrapper.ObservableList[2].Value = newValue;

            CheckSequence(list, wrapper);
            Assert.True(list[2] == newValue);
        }
    }
}
