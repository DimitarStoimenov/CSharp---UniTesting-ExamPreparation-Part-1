using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]

        public void CheckIfSmartphonePropertiesPasst()
        {
            Smartphone smartphone = new Smartphone("S5", 450);

            Assert.AreEqual(smartphone.ModelName, "S5");
            Assert.AreEqual(smartphone.MaximumBatteryCharge, 450);
            Assert.AreEqual(smartphone.CurrentBateryCharge, 450);

        }

        [Test]

        public void CheckfShopPhonesCountIsRight()
        {
            Shop shop = new Shop(2);
            List<Smartphone> phones = new List<Smartphone>();
            Smartphone smartphone1 = new Smartphone("S3", 350);
            Smartphone smartphone2 = new Smartphone("S5", 450);
            phones.Add(smartphone1);
            phones.Add(smartphone2);

            Assert.AreEqual(phones.Count, 2);
            Assert.AreEqual(shop.Capacity, 2);
            Assert.AreEqual(shop.Count, 0);
        }
        [Test]

        public void CheckfShopPhonesCountIsNotRight()
        {


            Assert.Throws<ArgumentException>(() => new Shop(-2));

        }

        [Test]

        public void CheckfShopPhonesnamesAreEqual()
        {
            Shop shop = new Shop(2);

            Smartphone smartphone1 = new Smartphone("S5", 350);



            shop.Add(smartphone1);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("S5", 450)));
        }
        [Test]

        public void CheckIfCountIsEqualToTheCapacity()
        {
            Shop shop = new Shop(2);

            Smartphone smartphone1 = new Smartphone("S3", 50);
            Smartphone smartphone2 = new Smartphone("S5", 360);
            shop.Add(smartphone1);
            shop.Add(smartphone2);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("S6", 450)));
        }

        [Test]

        public void RemovePhone()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone1 = new Smartphone("S3", 50);

            shop.Add(smartphone1);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("s4"));

        }

        [Test]

        public void IfProperlyremoveItem()
        {

            Shop shop = new Shop(1);
            Smartphone smartphone1 = new Smartphone("S3", 50);

            shop.Add(smartphone1);

            shop.Remove("S3");

            Assert.AreEqual(shop.Count, 0);
        }


        [Test]

        public void CheckIfBatteryIsIncreased()
        {

            Shop shop = new Shop(1);


            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("g2", 10));

        }
        [Test]

        public void CheckIfBatteryIsIncreasedBattery()
        {

            Shop shop = new Shop(1);
            List<Smartphone> phones = new List<Smartphone>();
            Smartphone smartphone1 = new Smartphone("S3", 50);
            shop.Add(smartphone1);


            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("S3", 60));

        }
        [Test]

        public void CheckIfBatteryIsIncreasedBatteryProperly()
        {

            Shop shop = new Shop(1);
            List<Smartphone> phones = new List<Smartphone>();
            Smartphone smartphone1 = new Smartphone("S3", 50);
            shop.Add(smartphone1);
            shop.TestPhone("S3", 10);



            Assert.AreEqual(smartphone1.CurrentBateryCharge, 40);

        }

        [Test]

        public void CheckIfBatteryChargingPhone()
        {

            Shop shop = new Shop(1);

            Smartphone smartphone1 = new Smartphone("S3", 50);
            shop.Add(smartphone1);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("f"));

        }
        [Test]

        public void CheckIfChargingPhone()
        {

            Shop shop = new Shop(1);

            Smartphone smartphone1 = new Smartphone("S3", 50);
            shop.Add(smartphone1);
            shop.TestPhone("S3", 20);
            shop.ChargePhone("S3");
            Assert.AreEqual(smartphone1.CurrentBateryCharge, 50);

        }




    }
}