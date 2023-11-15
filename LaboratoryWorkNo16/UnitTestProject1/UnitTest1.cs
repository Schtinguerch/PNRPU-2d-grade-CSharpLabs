using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WpfFileWorking.ViewModels;
using System.Collections.Specialized;
using Xunit;
using WpfFileWorking.Services;
using System.Windows.Controls;
using Task_2_DynamicTypeIdentification;
using WpfFileWorking.Views;

namespace UnitTestProject1
{
    public class ServiceTests
    {
        [Fact]
        public void CarSelected()
        {
            var service = new CarService();
            var selectedDialog = new CarSelectedDialogMock();

            var car = service.GetCarFromDialog(selectedDialog);
            Assert.NotNull(car);
        }

        [Fact]
        public void CarNotSelected()
        {
            var service = new CarService();
            var selectedDialog = new CarNotSelectedDialogMock();

            var car = service.GetCarFromDialog(selectedDialog);
            Assert.Null(car);
        }

        [Fact]
        public void NotValidInteger()
        {
            var validator = new IntegerValidationRule();
            var messages = new List<string>() { "", "hello", "-234yes", "23.33" };
            var expectedResult = new ValidationResult(false, IntegerValidationRule.NeedInteger);

            foreach (var message in messages)
            {
                var validationResult = validator.Validate(message, new System.Globalization.CultureInfo("en-US"));
                Assert.Equal(expectedResult, validationResult);
            }
        }

        [Fact]
        public void NotNaturalNumber()
        {
            var validator = new IntegerValidationRule();
            var messages = new List<string>() { "0", "-1", "-234" };
            var expectedResult = new ValidationResult(false, IntegerValidationRule.NeedNaturalNumberMessage);

            foreach (var message in messages)
            {
                var validationResult = validator.Validate(message, new System.Globalization.CultureInfo("en-US"));
                Assert.Equal(expectedResult, validationResult);
            }
        }

        [Fact]
        public void ValidInteger()
        {
            var validator = new IntegerValidationRule();
            var messages = new List<string>() { "1", "2", "3342" };
            var expectedResult = ValidationResult.ValidResult;

            foreach (var message in messages)
            {
                var validationResult = validator.Validate(message, new System.Globalization.CultureInfo("en-US"));
                Assert.Equal(expectedResult, validationResult);
            }
        }


        [Fact]
        public void Serialization()
        {
            var service = new TrainCarJsonService();
            var cars = TestPool.Cars;

            service.SerializeToFile(cars, "hello.json");
            var deserialized = service.DeserializedFromFile("hello.json");

            Assert.Equal(cars.Count, deserialized.Count);
            for (var i = 0; i < cars.Count; i += 1)
            {
                Assert.Equal(cars[i], deserialized[i]);
            }
        }

        [Fact]
        public void LocomotiveToViewModel()
        {
            var locomotive = TestPool.Cars[3];
            var converter = new TrainCarViewModelConverter();

            var actualViewModel = converter.Convert(locomotive, null, null, null);
            Assert.True(actualViewModel is LocomotiveCarViewModel);

            var locomotiveViewModel = actualViewModel as LocomotiveCarViewModel;
            Assert.Equal(locomotive, locomotiveViewModel.WrappedCar);
        }
    }
}
