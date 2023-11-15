using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using Task_2_DynamicTypeIdentification;
using WpfFileWorking.ViewModels;

namespace WpfFileWorking.Services
{
    public class TrainCarViewModelConverter : IValueConverter
    {
        private bool TryGetViewModel(object model, out ObservableObject viewModel)
        {
            if (model is EconomClass economClass)
            {
                viewModel = new EconomClassViewModel(economClass);
                return true;
            }

            if (model is CompartmentalCar compartmentalCar)
            {
                viewModel = new CompartmentalCarViewModel(compartmentalCar);
                return true;
            }

            if (model is Locomotive locomotive)
            {
                viewModel = new LocomotiveCarViewModel(locomotive);
                return true;
            }

            if (model is KitchenCar kitchenCar)
            {
                viewModel = new KitchenCarViewModel(kitchenCar);
                return true;
            }

            viewModel = null;
            return false;
        }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return new EmptyViewModel();
            }

            var viewModelFound = TryGetViewModel(value, out var viewModel);
            return viewModelFound ? viewModel : new EmptyViewModel();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICarWrapper observableCar)
            {
                return observableCar.GetTrainCar();
            }

            throw new ArgumentException("Is not ICarWrapper");
        }
    }
}