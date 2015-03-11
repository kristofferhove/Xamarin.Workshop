using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Core.Model;

namespace Xamarin.Core.Services
{
    public interface ICloudService
    {
        Task<MobileServiceCollection<Item, Item>> RefreshDataAsync();
        Task<MobileServiceCollection<Item, Item>> InsertAsync(Item item);
    }
}
