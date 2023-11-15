using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task_2_DynamicTypeIdentification;
using WpfFileWorking.Services;

namespace WpfFileWorking.ViewModels
{
    public class TrainsExplorerViewModel : ObservableObject
    {
        private static readonly DialogService DialogService = new DialogService();
        private static readonly TrainCarJsonService JsonService = new TrainCarJsonService();
        private static readonly CarService CarService = new CarService();
        private static readonly TrainCarViewModelConverter Converter = new TrainCarViewModelConverter();

        
        private List<TrainCar> _openedCars = new List<TrainCar>();
        private ObservableCollection<TrainCar> _shownCars = new ObservableCollection<TrainCar>();
        public ObservableCollection<TrainCar> ShownCars
        {
            get => _shownCars;
            set => SetProperty(ref _shownCars, value);
        }
        
        
        private string _currentFile = string.Empty;
        public string CurrentFile
        {
            get => _currentFile;
            set => SetProperty(ref _currentFile, value);
        }


        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                if (string.IsNullOrWhiteSpace(value))
                {
                    ShownCars = new ObservableCollection<TrainCar>(_openedCars);
                }

                var isNumber = int.TryParse(value.Trim(), out var numberValue);
                if (!isNumber)
                {
                    return;
                }

                var shownCars = _openedCars.Where(c => c.Length == numberValue || c.Mass == numberValue);
                ShownCars = new ObservableCollection<TrainCar>(shownCars);
            }
        }

        private TrainCar _selectedCar;
        public TrainCar SelectedCar
        {
            get => _selectedCar;
            set => SetProperty(ref _selectedCar, value);
        }

        private RelayCommand _openFileCommand;
        private RelayCommand _saveFileCommand;
        private RelayCommand _saveFileAsCommand;
        private RelayCommand _quitCommand;
        private RelayCommand _addCarCommand;
        private RelayCommand<TrainCar> _removeCarCommand;

        public IRelayCommand OpenFileCommand => _openFileCommand;
        public IRelayCommand SaveFileCommand => _saveFileCommand;
        public IRelayCommand SaveFileAsCommand => _saveFileAsCommand;
        public IRelayCommand QuitCommand => _quitCommand;
        public IRelayCommand AddCarCommand => _addCarCommand;
        public IRelayCommand<TrainCar> RemoveCarCommand => _removeCarCommand;

        private void OpenFile()
        {
            var path = DialogService.OpenFileDialogPath();
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            _openedCars = JsonService.DeserializedFromFile(path);

            SearchText = string.Empty;
            CurrentFile = path;
        }

        private void SaveCurrentFile()
        {
            if (string.IsNullOrEmpty(CurrentFile))
            {
                SaveFileAs();
            }
        }

        private void SaveFileAs()
        {
            var destinationPath = DialogService.SaveFileDialogPath();
            if (string.IsNullOrEmpty(destinationPath))
            {
                return;
            }
            
            JsonService.SerializeToFile(_openedCars, destinationPath);
        }

        private void Quit()
        {
            Application.Current.Shutdown(0);
        }

        private void AddCar()
        {
            var createdCar = CarService.GetCarFromDialog();
            if (createdCar is null)
            {
                return;
            }
            
            _openedCars.Add(createdCar);
            SearchText = string.Empty;
        }

        private void RemoveCar(TrainCar car)
        {
            _openedCars.Remove(car); 
            SearchText = string.Empty;
        }

        public TrainsExplorerViewModel()
        {
            _openFileCommand = new RelayCommand(OpenFile);
            _saveFileCommand = new RelayCommand(SaveCurrentFile);
            _saveFileAsCommand = new RelayCommand(SaveFileAs);
            _quitCommand = new RelayCommand(Quit);

            _addCarCommand = new RelayCommand(AddCar);
            _removeCarCommand = new RelayCommand<TrainCar>(RemoveCar);
        }
    }
}