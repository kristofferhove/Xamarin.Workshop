using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Core.Model
{
    public class Item 
    {
        public Item(string text)
        {
            Text = text;
        }

        public Item()
        {

        }

        public string Id { get; set; } 
        public string Text { get; set; } 
    }
}
