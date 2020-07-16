using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Models
{
    public class Menu
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public List<MenuItem> Items { get; set; }
        public string OrderTag { get; set; }
    }
}
