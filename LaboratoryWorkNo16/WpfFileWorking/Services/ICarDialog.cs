using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_DynamicTypeIdentification;

namespace WpfFileWorking.Services
{
    public interface ICarDialog
    {
        TrainCar SelectedCar { get; set; }
        bool? ShowDialog();
    }
}
