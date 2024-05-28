using RvanDijkLogic;
using RvanDijkLogic.Interfaces;

namespace Rvandijk_UnitTest
{
    [TestClass]
    public class ReserveringUnitTest
    {
        [TestMethod]
        public void GetReserveringenTestVoor1()
        {
            // Arrange
            MockDal mockdal = new MockDal();
            ReserveringLogic testRLogic = new ReserveringLogic(mockdal);

            // Act
            var TestResult = testRLogic.GetReserveringen();

            // Assert
            Assert.AreEqual(1, TestResult.Count());
            var Reservering = TestResult.First();
            Assert.AreEqual("Bert", Reservering.KlantNaam);
            Assert.AreEqual(1 , Reservering.ReservationID);

        }
        [TestMethod]
        public void GetReserveringenCount()
        {
            // Arrange
            MockDal mockdal = new MockDal();


            // Act
            ReserveringLogic testRLogic = new ReserveringLogic(mockdal);
            var TestResult = testRLogic.ReserveringCount();

            // Assert
            Assert.AreEqual(10, TestResult);
        }
    }
}