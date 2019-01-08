using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            List<Fruits> FruitsList = new List<Fruits>();
            Fruits fr = new Fruits();
            fr.Name = "梨";
            fr.Price =66;
            FruitsList.Add(fr);

            fr = new Fruits();
            fr.Name = "苹果";
            fr.Price = 88;
            FruitsList.Add(fr);

            foreach (var item in FruitsList)
            {
                Console.Write("Name:{0},价格:{1}",item.Name,item.Price);
            }
            Console.Read();

        }
    }
}
