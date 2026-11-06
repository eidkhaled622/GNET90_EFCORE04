using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNET90_EFCORE04.UI
{
    public class MenuItem
    {
        public string Title { get; set; }
        public Func<Task> Action { get; set; }
        public MenuItem(string Title, Func<Task> Action)
        {
            this.Title = Title;
            this.Action = Action;
        }
    }
}