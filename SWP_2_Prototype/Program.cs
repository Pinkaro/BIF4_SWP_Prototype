using SWP_2_Prototype.Prototypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_2_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //NoodleWhacker myVar = new NoodleWhacker(1, 1, 1, 1, "testElement");
            //dynamic test = Activator.CreateInstance(myVar.GetType(), 1, 1, 1, 1, "testElement");

            //Console.WriteLine(test.GetType());

            PrototypeManager manager = PrototypeManager.Instance;

            manager["Noodlewhacker of Fire"] = new NoodleWhacker(5,25,(float) 0.8,(float) 0.3, "fire");

            Console.WriteLine("################# MY PROTOTYPES #################");
            Console.WriteLine(manager.ToString() + "\n");
            Console.WriteLine("################### MY CLONES ###################");

            Sword dagger = manager["Dagger"].Clone() as Sword;
            NoodleWhacker whacker = manager["Noodlewhacker of Frost"].Clone() as NoodleWhacker;

            Console.WriteLine(dagger.ToString());
            Console.WriteLine(whacker.ToString());

            Console.ReadKey();
        }
    }
}
