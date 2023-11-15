using LaboratoryWorkNo12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_DynamicTypeIdentification;

namespace LabNo14Tests
{
    public static class TestPool
    {
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

        public static readonly List<TrainCar> DuplicatedCars = new List<TrainCar>()
        {
            Cars[0], Cars[0],
            Cars[3],
            Cars[6],
            Cars[4],
            Cars[6]
        };

        public static readonly MyOwnLinkedList<TrainCar> MyCars = new MyOwnLinkedList<TrainCar>();

        public static readonly List<TrainCar> CarSetA;
        public static readonly List<TrainCar> CarSetB;

        static TestPool()
        {
            CarSetA = Cars.Take(4).ToList();
            CarSetB = Cars.Skip(2).ToList();

            foreach (var car in Cars)
            {
                MyCars.Add(car);
            }
        }
    }
}
