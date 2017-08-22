using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas
{

    class Shape
    {
        int color = 10;
        int colorDos = 12;

        public Shape()
        {
            getArea();
        }

        public double sumatoria()
        {
            return color + colorDos;
        }

        public void getArea()
        {
            Console.WriteLine("Value is", sumatoria());
        }
    }

    class Connection
    {
       
    }
}
