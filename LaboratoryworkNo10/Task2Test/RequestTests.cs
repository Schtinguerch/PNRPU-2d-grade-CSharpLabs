using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2_DynamicTypeIdentification;
using System;
using System.Collections.Generic;

namespace Task2Test
{
    [TestClass]
    public class RequestTests
    {
        private Express _express = new Express("SchtMaschin", new List<TrainCar>()
        {
            new Locomotive(
                mass: 3,
                length: 8,
                enginePower: 2000,
                maxSpeed: 60),

            new Locomotive(
                mass: 4,
                length: 9,
                enginePower: 3100,
                maxSpeed: 70),

            new KitchenCar(
                mass: 7,
                length: 10,
                dishAssortiment: new List<string>
                {
                    "Стейк",
                    "Паста",
                    "Салат",
                    "Кальмар",
                }),

            new EconomClass(
                mass: 6,
                length: 10,
                passengerCapacity: 100,
                levelCount: 2),

            new EconomClass(
                mass: 5,
                length: 10,
                passengerCapacity: 80,
                levelCount: 2),

            new CompartmentalCar(
                mass: 8,
                length: 10,
                passengerCapacity: 80,
                includesSoundProofing: true),
        });

        [TestMethod]
        public void GetMassEngineCoefficient()
        {
            int rightCoef = 154;
            Assert.AreEqual(Request.GetPowerMassCoefficient(_express), rightCoef);
        }

        [TestMethod]
        public void InvalidCarCountRequest()
        {
            int rightCount = 0;
            int messageIndicator = 0;

            Request.OnRequestMessage += (s) =>
            {
                messageIndicator = 8989;
            };

            int count = Request.GetCarCount(_express, -1);
            count = Request.GetCarCount(_express, 1000);
            

            Assert.AreEqual(count, rightCount);
            count = Request.GetCarCount(_express, 200);

            Assert.AreEqual(count, rightCount);
            Assert.AreEqual(messageIndicator, 8989);
        }

        [TestMethod]
        public void CarCountRequest()
        {
            Assert.AreEqual(2, Request.GetCarCount(_express, 6));
        }

        [TestMethod]
        public void GetServiceLocomotiveCount()
        {
            Assert.AreEqual(0, Request.GetCountOfPassengers(_express, 5));
            Assert.AreEqual(0, Request.GetCountOfPassengers(_express, 4));
        }

        [TestMethod] 
        public void GetCountOfAllPassengers()
        {
            Assert.AreEqual(
                Request.GetCountOfPassengers(_express, 0),
                Request.GetCountOfPassengers(_express, 1));
        }

        [TestMethod] 
        public void CallNullEvents()
        {
            int count = Request.GetCarCount(_express, -1);
            count = Request.GetCountOfPassengers(_express, 0);
        }
    }
}
