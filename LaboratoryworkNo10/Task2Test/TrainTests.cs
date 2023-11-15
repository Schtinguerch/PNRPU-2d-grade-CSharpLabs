using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2_DynamicTypeIdentification;
using System;

namespace Task2Test
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void PassengerCarsInitialization()
        {
            InitiatePassengerCars(1, 1, 10, 1);
        }

        [TestMethod]
        public void PassengerCarInvalidInitialization()
        {
            Assert.ThrowsException<ArgumentException>(() => InitiatePassengerCars(-1, 1, 1, 1));
            Assert.ThrowsException<ArgumentException>(() => InitiatePassengerCars(1, -1, 1, 1));
            Assert.ThrowsException<ArgumentException>(() => InitiatePassengerCars(1, 1, -1, 1));
            Assert.ThrowsException<ArgumentException>(() => InitiatePassengerCars(1, 1, 1, -1));
        }

        private void InitiatePassengerCars(int mass, int length, int capacity, int levelCount)
        { 
            var economClass = new EconomClass(
                mass: mass,
                length: length,
                passengerCapacity: capacity,
                levelCount: levelCount);

            var compartmental = new CompartmentalCar(
                mass: mass,
                length: length,
                passengerCapacity: capacity,
                includesSoundProofing: true);

            Assert.AreEqual(economClass.Mass, mass);
            Assert.AreEqual(economClass.Length, length);
            Assert.AreEqual(economClass.PassengerCapacity, capacity);
            Assert.AreEqual(economClass.LevelCount, levelCount);

            var passengers = new string[]
            {
                "Алексей",
                "Дмитрий",
                "Валерий",
                "Виктория",
            };

            economClass.AddPassengers(passengers);
            Assert.AreEqual(passengers.Length, economClass.PassengerCount);
        }

        [TestMethod]
        public void AddTooManyPassengers()
        {
            var car = new EconomClass(
                mass: 2,
                length: 2,
                passengerCapacity: 2,
                levelCount: 2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => car.AddPassengers(
                    "aoeu",
                    "htsn",
                    "aoht",
                    "htns"));
        }

        [TestMethod]
        public void SetInvalidAdditionalParameters()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                var badLocomotive = new Locomotive(
                    mass: 1,
                    length: 1,
                    enginePower: -8,
                    maxSpeed: 1);
            });

            Assert.ThrowsException<ArgumentException>(() => {
                var badLocomotive = new Locomotive(
                    mass: 1,
                    length: 1,
                    enginePower: 1,
                    maxSpeed: -7);
            });
        }

        [TestMethod]
        public void InitiateServiceCars()
        {
            var locomotive = new Locomotive(
                mass: 1,
                length: 2,
                enginePower: 3,
                maxSpeed: 4);

            Assert.AreEqual(locomotive.EnginePower, 3);
            Assert.AreEqual(locomotive.MaxSpeed, 4);
        }
    }
}
