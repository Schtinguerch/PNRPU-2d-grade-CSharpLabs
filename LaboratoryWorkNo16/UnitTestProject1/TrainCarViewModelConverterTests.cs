using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WpfFileWorking.Services;
using WpfFileWorking.ViewModels;
using System.Collections.Specialized;
using Xunit;
using Task_2_DynamicTypeIdentification;

namespace UnitTestProject1
{
    public class TrainCarViewModelConverterTests
    {
        [Fact]
        public void WrapEconomClass()
        {
            var economClass = new EconomClass(1, 1, 1, 1);
            var converter = new TrainCarViewModelConverter();

            var viewModel = converter.Convert(economClass, null, null, null);

            Assert.True(viewModel is EconomClassViewModel);
            Assert.True((viewModel as EconomClassViewModel).GetTrainCar().Equals(economClass));
        }

        [Fact]
        public void WrapCompartmentalCar()
        {
            var compartmentalCar = new CompartmentalCar(1, 1, 1, true);
            var converter = new TrainCarViewModelConverter();

            var viewModel = converter.Convert(compartmentalCar, null, null, null);

            Assert.True(viewModel is CompartmentalCarViewModel);
            Assert.True((viewModel as CompartmentalCarViewModel).GetTrainCar().Equals(compartmentalCar));
        }

        [Fact]
        public void WrapLocomotive()
        {
            var locomotive = new Locomotive(1, 1, 1, 1);
            var converter = new TrainCarViewModelConverter();

            var viewModel = converter.Convert(locomotive, null, null, null);

            Assert.True(viewModel is LocomotiveCarViewModel);
            Assert.True((viewModel as LocomotiveCarViewModel).GetTrainCar().Equals(locomotive));
        }

        [Fact]
        public void WrapKitchen()
        {
            var kitchen = new KitchenCar(1, 1, new List<string>() { "aoeu" });
            var converter = new TrainCarViewModelConverter();

            var viewModel = converter.Convert(kitchen, null, null, null);

            Assert.True(viewModel is KitchenCarViewModel);
            Assert.True((viewModel as KitchenCarViewModel).GetTrainCar().Equals(kitchen));
        }

        [Fact]
        public void ConvertIncorrect()
        {
            var converter = new TrainCarViewModelConverter();
            var somethingWrong = "hello";

            var viewModel = converter.Convert(somethingWrong, null, null, null);
            Assert.True(viewModel is EmptyViewModel);
        }

        [Fact]
        public void ConvertNull()
        {
            var converter = new TrainCarViewModelConverter();

            var viewModel = converter.Convert(null, null, null, null);
            Assert.True(viewModel is EmptyViewModel);
        }

        [Fact]
        public void ConvertBack()
        {
            var locomotive = new Locomotive(1, 1, 1, 1);
            var viewModel = new LocomotiveCarViewModel(locomotive);

            var converter = new TrainCarViewModelConverter();
            var convertedLocomotive = converter.ConvertBack(viewModel, null, null, null);

            Assert.Equal(locomotive, convertedLocomotive);
        }

        [Fact]
        public void ConvertWithException()
        {
            var converter = new TrainCarViewModelConverter();
            Assert.Throws<ArgumentException>(() =>
            {
                var model = converter.ConvertBack("hello", null, null, null);
            });
        }
    }
}
