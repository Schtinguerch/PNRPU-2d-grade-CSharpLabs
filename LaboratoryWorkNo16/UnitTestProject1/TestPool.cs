using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_DynamicTypeIdentification;
using WpfFileWorking.Services;
using WpfFileWorking.ViewModels;

namespace UnitTestProject1
{
    public static class TestPool
    {
        public static List<string> StandardList => new List<string>()
        {
            "Dolorum qui consequatur ut doloribus doloremque culpa libero sint cum.",
            "Veritatis doloremque aut ut dolor minima et commodi.",
            "Quia fugiat sit cum.",
            "Repellendus aut nostrum.",
            "Corporis aperiam ut vel nisi et aut est ullam.",
            "Cupiditate tenetur minima cupiditate aut asperiores."
        };

        public static DeepObservableCollection<string> DeepObservableList => new DeepObservableCollection<string>(StandardList);


        public static DeepObservableCollection<ObservableString> DeepObservableOfObservables => new DeepObservableCollection<ObservableString>()
        {
            new ObservableString("Dolorum qui consequatur ut doloribus doloremque culpa libero sint cum."),
            new ObservableString("Veritatis doloremque aut ut dolor minima et commodi."),
            new ObservableString("Quia fugiat sit cum."),
            new ObservableString("Repellendus aut nostrum."),
            new ObservableString("Corporis aperiam ut vel nisi et aut est ullam."),
            new ObservableString("Cupiditate tenetur minima cupiditate aut asperiores.")
        };

        public static readonly List<TrainCar> Cars = new List<TrainCar>()
        {
            //0
            new CompartmentalCar(
                mass: 291,
                length: 732,
                passengerCapacity: 98,
                includesSoundProofing: true),

            //1
            new EconomClass(
                mass: 165,
                length: 94,
                passengerCapacity: 332,
                levelCount: 2),

            //2
            new EconomClass(
                mass: 128,
                length: 75,
                passengerCapacity: 254,
                levelCount: 1),

            //3
            new Locomotive(
                mass: 450,
                length: 91,
                enginePower: 2250,
                maxSpeed: 80),

            //4
            new Locomotive(
                mass: 528,
                length: 146,
                enginePower: 5280,
                maxSpeed: 211),

            //5
            new KitchenCar(
                mass: 996,
                length: 83,
                dishAssortiment: new List<string>
                {
                    "soba",
                    "meat",
                    "rise",
                    "pourage",
                    "pasta"
                }),

            //6
            new KitchenCar(
                mass: 127,
                length: 35,
                dishAssortiment: new List<string>
                {
                    "pasta",
                    "water",
                    "sauce",
                }),
        };

        public static bool AreSameSequence(List<string> rawSequence, DeepObservableCollection<ObservableString> observableSequence)
        {
            if (rawSequence.Count != observableSequence.Count)
            {
                return false;
            }

            var areSame = true;
            for (var i = 0; i < rawSequence.Count; i++)
            {
                if (rawSequence[i] != observableSequence[i].Value)
                {
                    areSame = false;
                }
            }

            return areSame;
        }
    }

    public class CarSelectedDialogMock : ICarDialog
    {
        public TrainCar SelectedCar { get; set; }

        public bool? ShowDialog()
        {
            return true;
        }

        public CarSelectedDialogMock()
        {
            SelectedCar = new EconomClass(1, 1, 1, 1);
        }
    }

    public class CarNotSelectedDialogMock : ICarDialog
    {
        public TrainCar SelectedCar { get; set; }

        public bool? ShowDialog()
        {
            return false;
        }
    }
}
