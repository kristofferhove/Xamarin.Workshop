using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fredrikstad.Forms.Models
{
    public class Item
    {
        public Item(string text)
        {
            Text = text;
        }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
