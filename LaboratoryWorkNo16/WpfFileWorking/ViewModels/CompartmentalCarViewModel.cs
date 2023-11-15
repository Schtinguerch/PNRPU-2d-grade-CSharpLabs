using CommunityToolkit.Mvvm.ComponentModel;
using Task_2_DynamicTypeIdentification;

namespace WpfFileWorking.ViewModels
{
    public class CompartmentalCarViewModel : ObservablePassengerCar<CompartmentalCar>
    {
        public CompartmentalCarViewModel(CompartmentalCar targetCar)
        {
            WrappedCar = targetCar;
            Passengers = new ListWrapper(WrappedCar.Passengers);
        }

        public CompartmentalCarViewModel()
        {
            WrappedCar = new CompartmentalCar(1, 1, 10, true);
            Passengers = new ListWrapper(WrappedCar.Passengers);
        }

        public bool IncludesSoundProofing
        {
            get => WrappedCar.IncludesSoundProofing;
            set => SetProperty(WrappedCar.IncludesSoundProofing, value, WrappedCar, (c, v) => c.IncludesSoundProofing = v);
        }
    }
}