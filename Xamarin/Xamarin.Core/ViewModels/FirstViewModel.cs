using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Collections.Generic;
using Xamarin.Core.Model;
using Xamarin.Core.Services;
using Xamarin.Core.Services.Messages;
using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace Xamarin.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel 
    {
        private readonly IItemGenesisService _itemGenesisService;
        private readonly IMvxMessenger _messenger;

        private readonly string applicationURL = "https://xamarinworkshop.azure-mobile.net/";
        private readonly string applicationKey = "AvPsdAyZoCFqltPAOOMBqFNcczEDYx22";
        const string localDbPath = "localstore.db";

        public MobileServiceClient client;
        public IMobileServiceSyncTable<Item> toDoTable;


        public FirstViewModel (IItemGenesisService itemGenesisService, IMvxMessenger messenger)
	    {
            _messenger = messenger;
            _itemGenesisService = itemGenesisService;

            


            client = new MobileServiceClient(applicationURL, applicationKey);
            toDoTable = client.GetSyncTable<Item>();

            //var newList = new List<Item>();
            //for (var i = 0; i < 10; i++)
            //{
            //    var newItem = _itemGenesisService.CreateNewItem(i.ToString());
            //    newList.Add(newItem);
            //}

            //ToDoList = newList;
            toDoTable = client.GetSyncTable<Item>();
            InitializeStoreAsync();
            RefreshAsync();
            
	    }

        private async Task RefreshAsync()
        {
            ToDoList = await toDoTable.ToListAsync();
        }

        public async Task InitializeStoreAsync()
        {
            var store = new MobileServiceSQLiteStore(localDbPath);
            store.DefineTable<Item>();
            await client.SyncContext.InitializeAsync(store);
        }

        public async Task SyncAsync()
        {
            try
            {
                await client.SyncContext.PushAsync();
                await toDoTable.PullAsync("allTodoItems", toDoTable.CreateQuery()); // query ID is used for incremental sync
            }

            catch (MobileServiceInvalidOperationException e)
            {
                var failed = e.Message;
                var readover = -1;
            }
        }

        public async Task<List<Item>> RefreshDataAsync()
        {
            try
            {
                await SyncAsync();
                ToDoList = await toDoTable.ToListAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                var failed = e.Message;
                var readover = -1;
                return null;
            }

            return ToDoList;
        }

        public async Task InsertTodoItemAsync(Item item)
        {
            try
            {
                await toDoTable.InsertAsync(item); // Insert a new TodoItem into the local database. 
                await SyncAsync(); // send changes to the mobile service

                ToDoList.Add(item);

            }
            catch (MobileServiceInvalidOperationException e)
            {
               var failed = e.Message;
               var readover = -1;
            }
        }


		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        private List<Item> _toDoList = new List<Item>();
        public List<Item> ToDoList 
        {
            get { return _toDoList; }
            set { _toDoList = value; RaisePropertyChanged(() => ToDoList); }
        }

        public MvxCommand AddItemCommand
        {
            get
            {
                return new MvxCommand(AddItem);
            }
        }

        private void AddItem()
        {
            var newlist = ToDoList;
            var insertItem = _itemGenesisService.addItem(Hello);
            newlist.Add(insertItem);
            InsertTodoItemAsync(insertItem);
            ToDoList = newlist;
            _messenger.Publish(new ReloadData(this));
        }
    }
}
