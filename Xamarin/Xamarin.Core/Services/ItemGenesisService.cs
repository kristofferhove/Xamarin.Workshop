using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Core.Model;

namespace Xamarin.Core.Services
{
    public class ItemGenesisService : IItemGenesisService
    {
        public Item CreateNewItem(string extra = "")
        {
            return new Item()
            {
                Text = "ElementViewModel" + extra
            };
        }

        public Item addItem(string text)
        {
            var test = text;
            return new Item()
            {
                Text = text
            };
        }
    }
}
