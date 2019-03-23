using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            double hight = 10.5;
            double width = 5.0;

            Forest forest = new Forest();
            for (int i = 0; i < 5; i++)
            {
                Tree birchTree = forest.GetTree("Береза");
                if (birchTree != null)
                    birchTree.Grow(hight, width);
                hight += 0.1;
                width += 0.1;
            }

            for (int i = 0; i < 5; i++)
            {
                Tree poplarTree = forest.GetTree("Тополь");
                if (poplarTree != null)
                    poplarTree.Grow(hight, width);
                hight += 0.2;
                width += 0.2;
            }

            Console.Read();
        }
        abstract class Tree
        {
            protected double hight; // высота
            protected double width; // ширина
            protected string type; // тип

            public abstract void Grow(double hight, double width);
        }

        class BirchTree : Tree
        {
            public BirchTree()
            {
                hight = 10.5;
                width = 2.0;
                type = "Береза";
            }

            public override void Grow(double hight, double width)
            {
                Console.WriteLine("Вырощена {0}; параметры: {1} высота и {2} ширина",
                    this.type, hight, width);
            }
        }
        class PoplarTree : Tree
        {
            public PoplarTree()
            {
                hight = 15.5;
                width = 3.0;
                type = "Тополь";
            }

            public override void Grow(double hight, double width)
            {
                Console.WriteLine("Вырощен {0}; параметры: {1} высота и {2} ширина",
                    this.type, hight, width);
            }
        }

        class Forest
        {
            Dictionary<string, Tree> houses = new Dictionary<string, Tree>();
            public Forest()
            {
                houses.Add("Береза", new BirchTree());
                houses.Add("Тополь", new PoplarTree());
            }

            public Tree GetTree(string key)
            {
                if (houses.ContainsKey(key))
                    return houses[key];
                else
                    return null;
            }
        }
    }
}
