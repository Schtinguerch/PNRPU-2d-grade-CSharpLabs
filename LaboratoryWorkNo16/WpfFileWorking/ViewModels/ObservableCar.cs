using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task_2_DynamicTypeIdentification;

namespace WpfFileWorking.ViewModels
{
    public abstract class ObservableCar<T> : ObservableObject, ICarWrapper where T : TrainCar
    {
        public T WrappedCar { get; set; }
        
        public int Mass
        {
            get => WrappedCar.Mass;
            set => SetProperty(WrappedCar.Mass, value, WrappedCar, (c, v) => c.Mass = v);
        }

        public int Length
        {
            get => WrappedCar.Length;
            set => SetProperty(WrappedCar.Length, value, WrappedCar, (c, v) => c.Length = v);
        }

        public TrainCar GetTrainCar()
        {
            return WrappedCar;
        }
    }
}