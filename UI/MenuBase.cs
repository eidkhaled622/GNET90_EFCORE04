using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNET90_EFCORE04.UI
{
    public abstract class MenuBase
    {
        protected abstract string Title { get; }
        protected abstract List<MenuItem> Items { get; }

        public void run()
        {
            while (true)
            {
                render();
                var choose = ConsoleInput.ReadInt("Choose", 0, Items.Count());

                if (choose == 0)
                {
                    return;
                }
                try
                {
                    Items[choose - 1].Action();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        public void render()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("                   National Bank - Management               ");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"------ {Title} ------");

            for (var i = 0; i < Items.Count(); i++)
            {
                Console.WriteLine($"{i + 1}) {Items[i].Title}");
            }
            Console.WriteLine("0) Exit The app");
        }
    }
}