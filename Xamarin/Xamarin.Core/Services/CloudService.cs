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

        public MobileServiceClient client;
        public IMobileServiceSyncTable<Item> toDoTable;

        public CloudService()
        {
            client = new MobileServiceClient(applicationURL, applicationKey);
            toDoTable = client.GetSyncTable<Item>();
        }

        public int MyProperty { get; set; }
    }
}
