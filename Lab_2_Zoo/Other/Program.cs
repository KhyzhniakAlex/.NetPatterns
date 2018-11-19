using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo Action;
            MainCage mc = new MainCage();
            List<ICageComponent> animals;

            Console.WriteLine("Команди для роботи з програмою:");
            Console.WriteLine("1) додати тварину - клавiша А;");
            Console.WriteLine("2) змiнити перiод доби - клавiша Т;");
            Console.WriteLine("3) команда голосу - клавiша V;");
            Console.WriteLine("4) вивести загальну вагу - клавiша W;");
            Console.WriteLine("5) додати клiтку - клавiша С \n");

            while (true)
            {
                Action = Console.ReadKey(true);

                switch (Action.Key)
                {
                    //додати тварину
                    case ConsoleKey.A:
                        Console.WriteLine("Вага тварини: ");
                        int weight;
                        if ((Int32.TryParse(Console.ReadLine(), out weight) == true))
                        {
                            mc.AddAnimal(weight);
                            animals = mc.GetAnimals();
                            foreach (var a in animals)
                            {
                                Console.WriteLine("Iм'я тварини: {0}, вага тварини: {1}", a.Name, a.Weight);
                            }
                        }
                        else Console.WriteLine("Невiрний формат введеного");
                        break;
                    //додати клітку
                    case ConsoleKey.C:
                        NewCage(mc);
                        Console.WriteLine("Клiтку додано");
                        break;
                    //змінити період дня
                    case ConsoleKey.T:
                        Console.WriteLine("Перiод дня: day - день, night - нiч");
                        string time = Console.ReadLine();
                        if (time == "day" || time == "night")
                        {
                            mc.Day(time);
                            Console.WriteLine("Час змiнено");
                        } 
                        else Console.WriteLine("Невiрний формат введеного");
                        break;
                    //подати голос
                    case ConsoleKey.V:
                        Console.WriteLine("Голос подає: всi тварини - all, окрема тварина - №");
                        string who = Console.ReadLine();
                        int number;
                        if (who == "all")
                            Console.WriteLine(mc.Voice());
                        else if (Int32.TryParse(who, out number))
                        {
                            number--;
                            ICageComponent a = mc.isOne(number);
                            if (a != null)
                            {
                                if (mc.isDay == false)
                                {
                                    mc.Day("day");
                                    Console.WriteLine(a.Voice());
                                    mc.Day("night");
                                }
                                else Console.WriteLine(a.Voice());
                            }
                            else Console.WriteLine("Це не тварина. Виберiть iнше мiсце");
                        }
                        else Console.WriteLine("Невiрний формат введеного");
                        break;
                    //загальна вага
                    case ConsoleKey.W:
                        Console.WriteLine("Загальна вага: {0}", mc.Weight);
                        break;
                }
            }
        }

        private static void NewCage(MainCage cage)
        {
            MainCage subCage = new MainCage();
            Random rw = new Random();
            subCage.AddAnimal(rw.Next(10, 120));
            cage.AddCage(subCage);
        }
    }
}
