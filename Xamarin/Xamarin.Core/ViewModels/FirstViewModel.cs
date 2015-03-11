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

namespace Xamarin.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel 
    {
        private readonly IMvxMessenger _messenger;
        private readonly ICloudService _cloudservice;

        //const string applicationURL = @"https://xamarinworkshop.azure-mobile.net/";
        //const string applicationKey = @"AvPsdAyZoCFqltPAOOMBqFNcczEDYx22";

        //private MobileServiceClient client;
        //private IMobileServiceTable<Item> todoTable;// = client.GetTable<Item>();
        //private MobileServiceCollection<Item, Item> items;

        public FirstViewModel (IMvxMessenger messenger, ICloudService cloudservice)
	    {
            _messenger = messenger;
            _cloudservice = cloudservice;

            //var newList = new List<Item>();
            //for (var i = 0; i < 10; i++)
            //{
            //    var newItem = new Item("Element " + i.ToString());
            //    newList.Add(newItem);
            //}

            //ToDoList = newList;
	    }

        public async void RefreshDataAsync()
        {
            ToDoList = await _cloudservice.RefreshDataAsync();

            //try
            //{
            //    // update the local store
            //    // all operations on todoTable use the local database, call SyncAsync to send changes
            //    //await SyncAsync();

            //    // This code refreshes the entries in the list view by querying the local TodoItems table.
            //    // The query excludes completed TodoItems
            //    //Items = await todoTable.ToListAsync();
            //    //ToDoList = await todoTable.ToCollectionAsync();// ToCollectionAsync();

            //    ToDoList = await _cloudservice.RefreshDataAsync();
            //    var test = 1;

            //}
            //catch (MobileServiceInvalidOperationException e)
            //{
            //    var error = e.Message;
            //    var stop = 1;
            //}
         }

		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        private MobileServiceCollection<Item, Item> _toDoList;
        public MobileServiceCollection<Item, Item> ToDoList
        {
            get { return _toDoList; }
            set { _toDoList = value; RaisePropertyChanged(() => ToDoList); }
        }

        //private List<Item> _toDoList;
        //public List<Item> ToDoList
        //{
        //    get { return _toDoList; }
        //    set { _toDoList = value; RaisePropertyChanged(() => ToDoList); }
        //}

        public MvxCommand AddItemCommand
        {
            get
            {
                return new MvxCommand(AddItem);
            }
        }

        private async void AddItem()
        {
            var item = new Item { Text = Hello };
            //ToDoList.Add(item);
            //_messenger.Publish(new ReloadData(this));
            ToDoList = await _cloudservice.InsertAsync(item);
        }
    }
}
