using CommunityToolkit.Mvvm.Input;
using Task_2_DynamicTypeIdentification;

namespace WpfFileWorking.ViewModels
{
    public abstract class ObservablePassengerCar<T> : ObservableCar<T> where T : PassengerCar
    {
        public int PassengerCapacity
        {
            get => WrappedCar.PassengerCapacity;
            set => SetProperty(WrappedCar.PassengerCapacity, value, WrappedCar, (c, v) => c.PassengerCapacity = v);
        }

        private ListWrapper _passengers;
        public ListWrapper Passengers
        {
            get => _passengers;
            set => SetProperty(ref _passengers, value);
        }

        private RelayCommand _addPassengerCommand;
        private RelayCommand<ObservableString> _removePassengerCommand;

        public IRelayCommand AddPassengerCommand => 
            _addPassengerCommand ?? (_addPassengerCommand = new RelayCommand(AddPassenger));
        public IRelayCommand<ObservableString> RemovePassengerCommand => 
            _removePassengerCommand ?? (_removePassengerCommand = new RelayCommand<ObservableString>(RemovePassenger));

        private void AddPassenger()
        {
            var newString = new ObservableString("Вася");
            Passengers.ObservableList.Add(newString);
        }

        private void RemovePassenger(ObservableString target)
        {
            Passengers.ObservableList.Remove(target);
        }
    }
}