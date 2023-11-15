using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Task_2_DynamicTypeIdentification;

namespace WpfFileWorking.ViewModels
{
    public class EconomClassViewModel : ObservablePassengerCar<EconomClass>
    {
        public EconomClassViewModel(EconomClass targetCar)
        {
            WrappedCar = targetCar;
            Passengers = new ListWrapper(WrappedCar.Passengers);
        }

        public EconomClassViewModel()
        {
            WrappedCar = new EconomClass(1, 1, 10, 1);
            Passengers = new ListWrapper(WrappedCar.Passengers);
        }

        public int LevelCount
        {
            get => WrappedCar.LevelCount;
            set => SetProperty(WrappedCar.LevelCount, value, WrappedCar, (c, v) => c.LevelCount = v);
        }
    }
}