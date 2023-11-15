using Task_2_DynamicTypeIdentification;

namespace WpfFileWorking.ViewModels
{
    public class LocomotiveCarViewModel : ObservableCar<Locomotive>
    {
        public LocomotiveCarViewModel(Locomotive targetCar)
        {
            WrappedCar = targetCar;
        }

        public LocomotiveCarViewModel()
        {
            WrappedCar = new Locomotive(1, 1, 1, 1);
        }

        public int EnginePower
        {
            get => WrappedCar.EnginePower;
            set => SetProperty(WrappedCar.EnginePower, value, WrappedCar, (c, v) => c.EnginePower = v);
        }

        public int MaxSpeed
        {
            get => WrappedCar.MaxSpeed;
            set => SetProperty(WrappedCar.MaxSpeed, value, WrappedCar, (c, v) => c.MaxSpeed = v);
        }
    }
}