using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfFileWorking.ViewModels
{
    public class ObservableString : ObservableObject
    {
        private string _value;
        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public ObservableString(string value) => Value = value;
        public ObservableString() => Value = string.Empty;
    }
}