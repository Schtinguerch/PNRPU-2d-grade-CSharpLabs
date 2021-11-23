using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LaboratoryWorkNo9;

namespace TriangleTests
{
    [TestClass]
    public class LengthSetupTests
    {
        [TestMethod]
        public void SetLessThanZeroLengths()
        {
            var someTriangle = new Triangle();

            Assert.ThrowsException<ArgumentException>(() => someTriangle.LengthAB = -1);
            Assert.ThrowsException<ArgumentException>(() => someTriangle.LengthBC = -6);
            Assert.ThrowsException<ArgumentException>(() => someTriangle.LengthAC = -0.0001);
        }
        
        [TestMethod]
        public void SetMoreThanZeroLengths()
        {
            var someTriangle = new Triangle();

            double expectedAB = 0;
            double expectedBC = 7;
            double expectedAC = 0.001;

            someTriangle.LengthAB = expectedAB;
            someTriangle.LengthBC = expectedBC;
            someTriangle.LengthAC = expectedAC;

            Assert.AreEqual(expectedAB, someTriangle.LengthAB);
            Assert.AreEqual(expectedBC, someTriangle.LengthBC);
            Assert.AreEqual(expectedAC, someTriangle.LengthAC);
        }
    }
}
