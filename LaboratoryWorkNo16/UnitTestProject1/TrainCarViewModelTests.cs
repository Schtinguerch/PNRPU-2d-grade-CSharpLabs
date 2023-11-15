using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WpfFileWorking.ViewModels;
using System.Collections.Specialized;
using Xunit;
using Task_2_DynamicTypeIdentification;
using System.Runtime.ConstrainedExecution;

namespace UnitTestProject1
{
    public class TrainCarViewModelTests
    {
        [Fact]
        public void LocomotiveInitialization()
        {
            var standardLocomotive = new Locomotive(1, 1, 1, 1);
            var standardLocomotiveViewModel = new LocomotiveCarViewModel();

            Assert.Equal(standardLocomotive, standardLocomotiveViewModel.WrappedCar);
        }

        [Fact]
        public void LocomotiveFields()
        {
            var standardLocomotive = new Locomotive(1, 1, 1, 1);
            var standardLocomotiveViewModel = new LocomotiveCarViewModel(standardLocomotive);

            Assert.Equal(standardLocomotive.MaxSpeed, standardLocomotiveViewModel.MaxSpeed);
            Assert.Equal(standardLocomotive.EnginePower, standardLocomotiveViewModel.EnginePower);

            var newSpeed = 56;
            standardLocomotiveViewModel.MaxSpeed = newSpeed;

            Assert.Equal(standardLocomotive.MaxSpeed, standardLocomotiveViewModel.MaxSpeed);
            Assert.Equal(newSpeed, standardLocomotive.MaxSpeed);

            var newPower = 1200;
            standardLocomotiveViewModel.EnginePower = newPower;

            Assert.Equal(standardLocomotive.EnginePower, standardLocomotiveViewModel.EnginePower);
            Assert.Equal(newPower, standardLocomotive.EnginePower);
        }


        [Fact]
        public void KitchenCarInitialization()
        {
            var kitchen = new KitchenCar(1, 1, new List<string>());
            var kitchenViewModel = new KitchenCarViewModel();

            Assert.True(kitchen.CompareTo(kitchenViewModel.WrappedCar) == 0);
        }

        [Fact]
        public void KitchenCarFields()
        {
            var kitchen = new KitchenCar(1, 1, TestPool.StandardList);
            var kitchenViewModel = new KitchenCarViewModel(kitchen);

            Assert.True(TestPool.AreSameSequence(kitchen.DishAssortiment, kitchenViewModel.Dishes.ObservableList));
        }

        [Fact]
        public void KitchenCarCommands()
        {
            var kitchen = new KitchenCar(1, 1, TestPool.StandardList);
            var kitchenViewModel = new KitchenCarViewModel(kitchen);

            var command = kitchenViewModel.AddDishCommand;
            Assert.NotNull(command);

            kitchenViewModel.AddDishCommand.Execute(null);
            Assert.Contains("Пюрешка", kitchen.DishAssortiment);

            command = kitchenViewModel.RemoveDishCommand; 
            Assert.NotNull(command);

            var forDelete = kitchenViewModel.Dishes.ObservableList[0];

            kitchenViewModel.RemoveDishCommand.Execute(forDelete);
            Assert.DoesNotContain(forDelete.Value, kitchen.DishAssortiment);
        }

        [Fact]
        public void EconomClassInitialization()
        {
            var car = new EconomClass(1, 1, 1, 1);
            var observableCar = new EconomClassViewModel();

            Assert.True(car.CompareTo(observableCar.WrappedCar) == 0);
        }

        [Fact]
        public void EconomClassFields()
        {
            var car = new EconomClass(1, 1, 1, 1);
            var observableCar = new EconomClassViewModel(car);

            Assert.Equal(observableCar.LevelCount, car.LevelCount);

            var newLevelCount = 2;
            observableCar.LevelCount = newLevelCount;

            Assert.Equal(car.LevelCount, observableCar.LevelCount);
            Assert.Equal(newLevelCount, car.LevelCount);
        }

        [Fact]
        public void CompartmentalCarInitialization()
        {
            var car = new CompartmentalCar(1, 1, 1, false);
            var observableCar = new CompartmentalCarViewModel();

            Assert.True(car.CompareTo(observableCar.WrappedCar) == 0);
        }

        [Fact] 
        public void CompartmentalCarFields()
        {
            var car = new CompartmentalCar(1, 1, 1, false);
            var observableCar = new CompartmentalCarViewModel(car);

            Assert.Equal(car.IncludesSoundProofing, observableCar.IncludesSoundProofing);

            var yes = true;
            observableCar.IncludesSoundProofing = yes;

            Assert.Equal(car.IncludesSoundProofing, observableCar.IncludesSoundProofing);
            Assert.Equal(yes, car.IncludesSoundProofing);
        }
    }
}
