using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Models
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
        public List<MenuItem> Items { get; set; }
        public decimal Price { get; set; }
        public List<string> SubMenus { get; set; }

        public bool? SubMenuVisibility => SubMenus?.Count > 0;
        public bool? ArrowVisiblity => SubMenus?.Count > 0 || Items?.Count > 0;
        public bool? PriceVisibility => Price > 0;
    }
}
