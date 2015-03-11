using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Xamarin.Core.Model;

namespace Xamarin.iOS.Services
{
    public class QSTodoService
    {
        static QSTodoService instance = new QSTodoService();

        const string applicationURL = @"https://xamarinworkshop.azure-mobile.net/";
        const string applicationKey = @"AvPsdAyZoCFqltPAOOMBqFNcczEDYx22";

        private MobileServiceClient client;
        //private IMobileServiceSyncTable<Item> todoTable;
        private IMobileServiceTable<Item> todoTable;// = client.GetTable<Item>();
        private MobileServiceCollection<Item, Item> items;

        private QSTodoService()
        {
            CurrentPlatform.Init();
            //SQLitePCL.CurrentPlatform.Init();

            // Initialize the Mobile Service client with your URL and key
            client = new MobileServiceClient(applicationURL, applicationKey);

            // Create an MSTable instance to allow us to work with the TodoItem table
            //todoTable = client.GetSyncTable<Item>();
            todoTable = client.GetTable<Item>();
        }

        public static QSTodoService DefaultService
        {
            get
            {
                return instance;
            }
        }

        public MobileServiceCollection<Item, Item> Items { get; private set; }

        //public async Task InitializeStoreAsync()
        //{
        //    var store = new MobileServiceSQLiteStore(localDbPath);
        //    store.DefineTable<Item>();

        //    // Uses the default conflict handler, which fails on conflict
        //    // To use a different conflict handler, pass a parameter to InitializeAsync. For more details, see http://go.microsoft.com/fwlink/?LinkId=521416
        //    await client.SyncContext.InitializeAsync(store);
        //}

        //public async Task SyncAsync()
        //{
        //    try
        //    {
        //        await client.SyncContext.PushAsync();
        //        await todoTable.PullAsync("allTodoItems", todoTable.CreateQuery()); // query ID is used for incremental sync
        //    }

        //    catch (MobileServiceInvalidOperationException e)
        //    {
        //        Console.Error.WriteLine(@"Sync Failed: {0}", e.Message);
        //    }
        //}

        //
        public async Task<MobileServiceCollection<Item, Item>> RefreshDataAsync()
        {
            try
            {
                // update the local store
                // all operations on todoTable use the local database, call SyncAsync to send changes
                //await SyncAsync();

                // This code refreshes the entries in the list view by querying the local TodoItems table.
                // The query excludes completed TodoItems
                //Items = await todoTable.ToListAsync();
                Items = await todoTable.ToCollectionAsync();// ToCollectionAsync();

            }
            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
                return null;
            }

            return Items;
        }

        public async Task InsertTodoItemAsync(Item item)
        {
            try
            {
                await todoTable.InsertAsync(item); // Insert a new TodoItem into the local database. 
                //await SyncAsync(); // send changes to the mobile service

                Items.Add(item);

            }
            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }
    }
}