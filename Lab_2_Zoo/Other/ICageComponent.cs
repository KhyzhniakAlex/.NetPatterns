using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Zoo
{
    public interface ICageComponent
    {
        int Weight { get; }
        string Name { get; }

        string Voice();
    }
}
