using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaboratoryWorkNo11.Menu;
using Task_2_DynamicTypeIdentification;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestsForTasksNo1
{
    [TestClass]
    public class StackManipulatorTests
    {
        [TestMethod]
        public void DeleteLastCar()
        {
            StackManipulator.CarStack = new Stack();

            for (int i = 0; i < 9; i++)
                StackManipulator.CarStack.Push(TrainCarCreator.NewRandomCar());

            var lastCar = TrainCarCreator.NewRandomCar();
            StackManipulator.CarStack.Push(lastCar);

            var deletedCar = StackManipulator.CarStack.Pop();
            Assert.AreEqual(lastCar, deletedCar);
        }

        [TestMethod]
        public void ConvertToStack()
        {
            var itemList = new List<TrainCar>()
            {
                new Locomotive(1, 2, 3, 4),
                new KitchenCar(2, 3, new List<string> { "4", "5"}),
                new CompartmentalCar(4, 5, 6, true),
            };

            var stack = itemList.ToStack();
            Assert.AreEqual(stack.Pop() is CompartmentalCar, true);
            Assert.AreEqual(stack.Pop() is KitchenCar, true);
            Assert.AreEqual(stack.Pop() is Locomotive, true);
        }

        [TestMethod]
        public void ConvertToList()
        {
            var itemList = new List<TrainCar>()
            {
                new Locomotive(1, 2, 3, 4),
                new KitchenCar(2, 3, new List<string> { "4", "5"}),
                new CompartmentalCar(4, 5, 6, true),
            };

            var stack = itemList.ToStack();
            var theSameList = StackManipulator.ToList(stack);

            theSameList.Reverse();
            Assert.AreEqual(itemList.SequenceEqual(theSameList), true);
        }
    }
}
