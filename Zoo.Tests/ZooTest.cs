using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_2_Zoo;
using System.Collections.Generic;

namespace Zoo.Tests
{
    [TestClass]
    public class ZooTest
    {
        [TestMethod]
        public void AnimalCreate()
        {
            AnimalCreator ac = new AnimalCreator();

            Animal animal;
            Type[] expected = { typeof(Bear), typeof(Wolf), typeof(Giraffe) };

            animal = ac.Create();

            foreach (var type in expected)
            {
                if (type == animal.GetType()) Assert.AreEqual(type, animal.GetType());
            }
        }

        [TestMethod]
        public void AddAnimal()
        {
            MainCage mc = new MainCage();

            int weight = 10;
            int number = 0;
            Type[] expected = { typeof(Bear), typeof(Wolf), typeof(Giraffe) };

            mc.AddAnimal(weight);
            ICageComponent component = mc.isOne(number);

            foreach (var type in expected)
            {
                if (type == component.GetType()) Assert.AreEqual(type, component.GetType());
            }
        }

        [TestMethod]
        public void AddNewCage()
        {
            MainCage mc = new MainCage();
            int number = 0;

            mc.AddCage(mc);

            ICageComponent expected = mc;
            ICageComponent component = mc.isOne(number);

            Assert.AreEqual(expected.GetType(), component.GetType());
        }

        [TestMethod]
        public void VoiceBear()
        {
            MainCage mc = new MainCage();

            Animal bear = new Bear();
            string expected = "It's a BEAR!";

            string v = bear.Voice();

            Assert.AreEqual(expected, v);
        }

        [TestMethod]
        public void VoiceWolf()
        {
            MainCage mc = new MainCage();

            Animal wolf = new Wolf();
            string expected = "It's a WOLF WOLF WOLF ! ! !";

            string v = wolf.Voice();

            Assert.AreEqual(expected, v);
        }

        [TestMethod]
        public void VoiceGiraffe()
        {
            MainCage mc = new MainCage();

            Animal giraffe = new Giraffe();
            string expected = "It's a GIRAFFE!";

            string v = giraffe.Voice();

            Assert.AreEqual(expected, v);
        }

        [TestMethod]
        public void OneFromListComponent()
        {
            MainCage mc = new MainCage();
            Animal wolf = new Wolf();
            Animal bear = new Bear();
            Animal giraffe = new Giraffe();
            List<ICageComponent> components = new List<ICageComponent>();
            components.Add(wolf);
            components.Add(bear);
            components.Add(giraffe);

            int number = 0;
            int weight = 50;
            ICageComponent component;

            mc.AddAnimal(weight);
            component = mc.isOne(number);

            foreach (var expected in components)
            {
                if(expected.GetType() == component.GetType()) Assert.AreEqual(expected.GetType(), component.GetType());
            }  
        }

        [TestMethod]
        public void CageFromListComponent()
        {
            MainCage mc = new MainCage();
            List<ICageComponent> components = new List<ICageComponent>();
            components.Add(mc);

            int number = 0;
            mc.AddCage(mc);

            ICageComponent component = mc.isOne(number);
            ICageComponent expected = components[number];

            Assert.AreEqual(expected.GetType(), component.GetType());
        }

        [TestMethod]
        public void GetAnimalsForReading()
        {
            MainCage mc = new MainCage();
            List<ICageComponent> list;
            List<ICageComponent> expected = new List<ICageComponent>();

            list = mc.GetAnimals();

            Assert.AreEqual(expected.GetType(), list.GetType());
        }

        [TestMethod]
        public void CheckParameterForDay()
        {
            MainCage mc = new MainCage();
            bool expected = true;
            string time = "day";

            mc.Day(time);

            Assert.AreEqual(expected, mc.isDay);

            expected = false;
            time = "night";

            mc.Day(time);

            Assert.AreEqual(expected, mc.isDay);
        }
    }
}
