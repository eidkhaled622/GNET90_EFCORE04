using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNET90_EFCORE04.UI.Menus
{
    public class MainMenu : MenuBase
    {
        private readonly List<MenuItem> _items;
        public MainMenu(CreateCustomer create, OpenAccount open, UpdateStatus update)
        {
            _items = new List<MenuItem>{
                new("Create Account", create.run),
                new("Open Account" , open.run),
                new("Update Account Status" , update.run)
            };
        }
        protected override string Title => "Main Menu";

        protected override List<MenuItem> Items => _items;
    }
}