using Task_2_DynamicTypeIdentification;
using WpfFileWorking.Views;

namespace WpfFileWorking.Services
{
    public class CarService
    {
        public TrainCar GetCarFromDialog(ICarDialog dialog = null)
        {
            if (dialog is null)
            {
                dialog = new NewCarVindow();
            }
 
            if (dialog.ShowDialog() == true)
            {
                return dialog.SelectedCar;
            }

            //User cancelled the selection
            return null;
        }
    }
}