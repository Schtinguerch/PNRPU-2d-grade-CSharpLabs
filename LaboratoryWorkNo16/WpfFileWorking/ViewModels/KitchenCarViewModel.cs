using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using Task_2_DynamicTypeIdentification;

namespace WpfFileWorking.ViewModels
{
    public class KitchenCarViewModel : ObservableCar<KitchenCar>
    {
        public KitchenCarViewModel(KitchenCar targetCar)
        {
            WrappedCar = targetCar;
            Dishes = new ListWrapper(WrappedCar.DishAssortiment);
        }

        public KitchenCarViewModel()
        {
            WrappedCar = new KitchenCar(1, 1, new List<string>());
            Dishes = new ListWrapper(WrappedCar.DishAssortiment);
        }

        private ListWrapper _dishes;
        public ListWrapper Dishes
        {
            get => _dishes;
            set => SetProperty(ref _dishes, value);
        }
        
        private RelayCommand _addDishCommand;
        private RelayCommand<ObservableString> _removeDishCommand;

        public IRelayCommand AddDishCommand => 
            _addDishCommand ?? (_addDishCommand = new RelayCommand(AddDish));
        public IRelayCommand<ObservableString> RemoveDishCommand => 
            _removeDishCommand ?? (_removeDishCommand = new RelayCommand<ObservableString>(RemoveDish));

        private void AddDish()
        {
            var newString = new ObservableString("Пюрешка");
            Dishes.ObservableList.Add(newString);
        }

        private void RemoveDish(ObservableString target)
        {
            Dishes.ObservableList.Remove(target);
        }
    }
}