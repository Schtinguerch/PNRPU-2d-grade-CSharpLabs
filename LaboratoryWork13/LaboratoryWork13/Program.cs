using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LaboratoryWorkNo12;
using Task_2_DynamicTypeIdentification;

namespace LaboratoryWork13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
        
            var firstCollection = new MyNewLinkedList<TrainCar>("Первая коллекция вагонов");
            var secondCollection = new MyNewLinkedList<TrainCar>("Вторая коллекция вагонов");

            var firstJournal = new Journal("Первый журнал");
            var secondJournal = new Journal("Второй журнал");

            firstCollection.CollectionCountChanged += new CollectionHandler(firstJournal.CollectionCountChanged);
            secondCollection.CollectionCountChanged += new CollectionHandler(secondJournal.CollectionCountChanged);

            firstCollection.CollectionReferenceChanged += new CollectionHandler(firstJournal.CollectionReferenceChanged);
            secondCollection.CollectionReferenceChanged += new CollectionHandler(secondJournal.CollectionReferenceChanged);

            for (int i = 0; i < 10; i += 1)
            {
                firstCollection.Add(TrainCarCreator.NewRandomCar());
                secondCollection.Add(TrainCarCreator.NewRandomCar());
            }

            var compartmentalCar = TrainCarCreator.NewRandomCompartmentalCar();
            var kitchenCar = TrainCarCreator.NewRandomKitchenCar();

            firstCollection[3] = compartmentalCar;
            secondCollection[0] = kitchenCar;

            firstCollection.Remove(compartmentalCar);
            secondCollection.Remove(kitchenCar);

            Console.WriteLine(firstJournal.ToString());
            Console.WriteLine(secondJournal.ToString());
        }
    }
}
