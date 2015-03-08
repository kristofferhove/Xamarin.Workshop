using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Core.Model;

namespace Xamarin.Core.Services
{
    public interface IItemGenesisService
    {
        Item CreateNewItem(string extra = "");
        Item addItem(string text);
    }
}
