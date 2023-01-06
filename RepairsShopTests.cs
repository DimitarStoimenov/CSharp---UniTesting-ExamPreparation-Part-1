using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]

            public void CheckIfCarPropertiesAreCorectlySet()
            {
                Car car = new Car("Opel", 0);

                Assert.AreEqual(car.CarModel, "Opel");
                Assert.AreEqual(car.NumberOfIssues, 0);
            }
           
        }

        [TestCase(null)]
        [TestCase("")]

        public void CheckIfGrageConstructorThrowsNameExeption(string name)
        {

            Assert.Throws<ArgumentNullException>(() => new Garage(name, 0));

        }
        [TestCase(0)]
        [TestCase(-1)]

        public void CheckIfThrowsMechanicsExeptionIfValueIsLowerThanZero(int count)
        {

            Assert.Throws<ArgumentException>(() => new Garage("Test", count));

        }

        [Test]

        public void CheckIfCountCarsAreSuccsesfulyAdd()
        {
            Garage garage = new Garage("Test", 1);

            Car car = new Car("Opel", 1);

            garage.AddCar(car);

            Assert.AreEqual(garage.CarsInGarage, 1);
            
        }
        [Test]

        public void CheckIfCountThrowsExeptionfulyAdd()
        {
            Garage garage = new Garage("Test", 1);

            Car car = new Car("Opel", 1);
            garage.AddCar(car);
            

            Assert.Throws<InvalidOperationException>(() => garage.AddCar(car));

        }




    }
}