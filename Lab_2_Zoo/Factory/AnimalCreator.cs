using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Zoo
{
    public class AnimalCreator
    {
        private Random rnd = new Random();
        private static int number = 1;

        public Animal Create()
        {
            int elem = rnd.Next(1, 11);

            if (elem <= 4)
            {
                Animal wolf = new Wolf();
                wolf.Name = number++ + ")" + "WOLF";
                return wolf;
            }
                
            else if (elem >= 5 && elem <= 8)
            {
                Animal bear = new Bear();
                bear.Name = number++ + ")" + "bear";
                return bear;
            }

            else if (elem >= 9)
            {
                Animal giraffe = new Giraffe();
                giraffe.Name = number++ + ")" + "GiraFFe";
                return giraffe;
            }
            else return null;
        }
    }
}
