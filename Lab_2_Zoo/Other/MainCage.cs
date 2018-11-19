using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Zoo
{
    public class MainCage : ICageComponent
    {
        private List<ICageComponent> components = new List<ICageComponent>();
        public bool isDay { get; set; } = true;

        public void AddAnimal(int weight)
        {
            AnimalCreator ac = new AnimalCreator();
            Animal animal = ac.Create();
            animal.Weight = weight;
            components.Add(animal);
        }

        public void Day(string time)
        {
            if (time == "day") isDay = true;
            else if (time == "night") isDay = false;
            else return;
        }

        public string Voice()
        {
            string voice = "";

            if (isDay == false) return null;
            else if (isDay)
            {
                foreach (var comp in components)
                {
                    voice += comp.Voice() + "\n";
                    comp.Voice();
                }
            }

            return voice;
        }

        public string Name
        {
            get
            {
                string n = "";
                foreach (var a in components)
                {
                    n = a.Name;
                }
                return n;
            }
        }

        public int Weight
        {
            get
            {
                int total = 0;
                foreach (var a in components)
                {
                    total += a.Weight;
                }
                return total;
            }
        }

        public void AddCage(ICageComponent cage)
        {
            components.Add(cage);
        }

        public ICageComponent isOne(int number)
        {
            return components[number];
        }

        public List<ICageComponent> GetAnimals()
        {
            List<ICageComponent> animal = new List<ICageComponent>();
            
            foreach (var a in components)
            {
                 animal.Add(a);
            }

            return animal;
        }
    }
}
