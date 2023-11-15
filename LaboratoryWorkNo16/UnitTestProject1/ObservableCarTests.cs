using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WpfFileWorking.ViewModels;
using System.Collections.Specialized;
using Xunit;
using Task_2_DynamicTypeIdentification;
using CommunityToolkit.Mvvm.Input;

namespace UnitTestProject1
{
    public class ObservableCarTests
    {
        [Fact]  
        public void TrainCarBaseInitialization()
        {
            var car = new Locomotive(1, 1, 1, 1);
            var observableCar = new LocomotiveCarViewModel(car);

            Assert.Equal(car.Mass, observableCar.Mass);
            Assert.Equal(car.Length, observableCar.Length);
        }

        [Fact]
        public void TrainCarBaseChanging()
        {
            var car = new Locomotive(1, 1, 1, 1);
            var observableCar = new LocomotiveCarViewModel(car);

            observableCar.Mass = 25;
            observableCar.Length = 100;

            Assert.Equal(car.Mass, observableCar.Mass);
            Assert.Equal(car.Length, observableCar.Length);
        }

        [Fact]
        public void PassengerCarBaseInitialization()
        {
            var car = new EconomClass(1, 1, 1, 1);
            var observableCar = new EconomClassViewModel(car);

            Assert.Equal(car.PassengerCapacity, observableCar.PassengerCapacity);
            Assert.True(TestPool.AreSameSequence(car.Passengers, observableCar.Passengers.ObservableList));
        }

        [Fact]
        public void PassengerCarBaseSetup()
        {
            var car = new EconomClass(1, 1, 1, 1);
            var observableCar = new EconomClassViewModel(car);

            var str = "hello";
            var observable = new ObservableString(str);

            observableCar.Passengers.ObservableList.Add(observable);

            Assert.Contains(str, car.Passengers);
            Assert.Contains(observable, observableCar.Passengers.ObservableList);
            Assert.True(TestPool.AreSameSequence(car.Passengers, observableCar.Passengers.ObservableList));

            var newCapacity = 18;
            observableCar.PassengerCapacity = newCapacity;

            Assert.Equal(car.PassengerCapacity, observableCar.PassengerCapacity);
            Assert.Equal(newCapacity, observableCar.PassengerCapacity);
        }

        [Fact]
        public void AddPassengerCommand()
        {
            var car = new EconomClass(1, 1, 1, 1);
            var observableCar = new EconomClassViewModel(car);

            var command = observableCar.AddPassengerCommand;
            Assert.NotNull(command);

            observableCar.AddPassengerCommand.Execute(null);
            Assert.Contains("Вася", car.Passengers);
        }

        [Fact]
        public void RemovePassengerCommand()
        {
            var car = new EconomClass(1, 1, 100, 1);
            car.AddPassengers("nikita", "mikhail");

            var observableCar = new EconomClassViewModel(car);

            var command = observableCar.RemovePassengerCommand;
            Assert.NotNull(command);

            var forDelete = observableCar.Passengers.ObservableList.Single(s => s.Value == "nikita");

            observableCar.RemovePassengerCommand.Execute(forDelete);
            Assert.DoesNotContain("nikita", car.Passengers);
        }
    }
}
