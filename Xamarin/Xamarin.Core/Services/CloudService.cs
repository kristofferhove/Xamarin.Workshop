using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Core.Model;

namespace Xamarin.Core.Services
{
    public class CloudService : ICloudService
    {
        private readonly string applicationURL = "https://xamarinworkshop.azure-mobile.net/";
        private readonly string applicationKey = "AvPsdAyZoCFqltPAOOMBqFNcczEDYx22";

        private MobileServiceClient client;
        private IMobileServiceTable<Item> todoTable;
        private MobileServiceCollection<Item, Item> items;

        public async Task<MobileServiceCollection<Item, Item>> RefreshDataAsync()
        {
            try
            {
                using (var client = new MobileServiceClient(applicationURL, applicationKey))
                {
                    items = await client.GetTable<Item>().ToCollectionAsync();
                }
            }
            catch (MobileServiceInvalidOperationException e)
            {
                var error = e.Message;
                var stop = 1;
            }

            return items;
        }

        public async Task<MobileServiceCollection<Item, Item>> InsertAsync(Item item)
        {
            try
            {
                using (var client = new MobileServiceClient(applicationURL, applicationKey))
                {
                    todoTable = client.GetTable<Item>();
                    await todoTable.InsertAsync(item);
                    items = await todoTable.ToCollectionAsync();
                }
            }
            catch (MobileServiceInvalidOperationException e)
            {
                var error = e.Message;
                var stop = 1;
            }

            return items;
        }
    }
}
