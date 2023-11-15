using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2_DynamicTypeIdentification;
using System;
using System.Collections.Generic;

namespace Task2Test
{
    [TestClass]
    public class ExpressTests
    {
        [TestMethod]
        public void InitiateUsableExpress()
        {
            var cars = new List<TrainCar>()
            {
                new Locomotive(
                    mass: 2,
                    length: 9,
                    enginePower: 900,
                    maxSpeed: 60),

                new KitchenCar(
                    mass: 7,
                    length: 12,
                    dishAssortiment: new List<string>() 
                    {
                        "Форель",
                        "Лопатка",
                    }),

                new CompartmentalCar(
                    mass: 4,
                    length: 10,
                    passengerCapacity: 100,
                    includesSoundProofing: true),

                new EconomClass(
                    mass: 5,
                    length: 12,
                    passengerCapacity: 120,
                    levelCount: 2)
            };

            var express = new Express("sch", cars);
            Assert.AreEqual(express.AbleToUsing, true);
        }

        [TestMethod]
        public void InitiateUnusableExpress()
        {
            List<TrainCar> zeroCar = new List<TrainCar>();

            var express = new Express("anull", null);
            var zeroExpress = new Express("azero", zeroCar);

            Assert.AreEqual(express.AbleToUsing, false);
            Assert.AreEqual(zeroExpress.AbleToUsing, false);
        }

        [TestMethod]
        public void GetValidCountOfPassengers()
        {
            var cars = new List<TrainCar>()
            {
                new Locomotive(
                    mass: 1,
                    length: 1,
                    enginePower: 1,
                    maxSpeed: 1),

                new EconomClass(
                    mass: 1,
                    length: 1,
                    passengerCapacity: 100,
                    levelCount: 2),

                new CompartmentalCar(
                    mass: 1,
                    length: 1,
                    passengerCapacity: 100,
                    includesSoundProofing: true),
            };

            var passengers1 = new string[]
            {
                "Lololo",
                "Schtinguerch",
                "Sa1gonix",
            };

            var passengers2 = new string[]
            {
                "Jacque Fresco",
                "Eugenium Prokopenko",
                "Umnique Michin",
            };

            (cars[1] as EconomClass).AddPassengers(passengers1);
            (cars[2] as CompartmentalCar).AddPassengers(passengers2);

            var express = new Express("SuperExpress", cars);
            Assert.AreEqual(passengers1.Length + passengers2.Length, express.PassengerCount);
        }

        [TestMethod]
        public void GetInvalidCountOfPassengers()
        {
            var express = new Express("BadEx", null);
            Assert.AreEqual(express.PassengerCount, 0);

            var express2 = new Express("BadE", new List<TrainCar>());
            Assert.AreEqual(express2.PassengerCount, 0);
        }
    }
}
