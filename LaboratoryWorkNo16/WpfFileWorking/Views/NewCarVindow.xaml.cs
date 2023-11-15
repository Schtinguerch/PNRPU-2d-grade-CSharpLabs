using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Task_2_DynamicTypeIdentification;
using WpfFileWorking.Services;

namespace WpfFileWorking.Views
{
    public partial class NewCarVindow : Window, ICarDialog
    {
        public NewCarVindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedCarProperty = DependencyProperty.Register(
            nameof(SelectedCar), 
            typeof(TrainCar), 
            typeof(NewCarVindow), 
            new PropertyMetadata(default(TrainCar)));

        public TrainCar SelectedCar
        {
            get => (TrainCar)GetValue(SelectedCarProperty);
            set => SetValue(SelectedCarProperty, value);
        }
        
        private TrainCar GetCarFromSelectionIndex(int index)
        {
            switch (index)
            {
                case 0: return new EconomClass(1, 1, int.MaxValue, 1);
                case 1: return new CompartmentalCar(1, 1, int.MaxValue, true);
                case 2: return new KitchenCar(1, 1, new List<string>());
                default: return new Locomotive(1, 1, 1, 1);
            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = CarComboBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }

            SelectedCar = GetCarFromSelectionIndex(selectedIndex);
            this.DialogResult = true;
        }
    }
}