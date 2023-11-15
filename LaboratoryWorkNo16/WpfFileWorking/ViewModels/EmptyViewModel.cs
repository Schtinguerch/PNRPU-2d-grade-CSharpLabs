using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfFileWorking.ViewModels
{
    public class EmptyViewModel : ObservableObject
    {
        public readonly string Message = "Выберите вагон или откройте json-файл чтобы получить список вагонов";
    }
}