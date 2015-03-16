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

        public FirstViewModel (IMvxMessenger messenger, ICloudService cloudservice)
	    {
            _messenger = messenger;
            _cloudservice = cloudservice;
	    }

        public async void RefreshDataAsync()
        {
            ToDoList = await _cloudservice.RefreshDataAsync();
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
            ToDoList = await _cloudservice.InsertAsync(item);
        }
    }
}
