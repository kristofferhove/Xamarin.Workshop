using Fredrikstad.Forms.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fredrikstad.Forms.ViewModels
{
    public class ItemsTableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly MobileServiceClient _client;

        public ItemsTableViewModel(MobileServiceClient client)
        {
            _client = client;
            ItemsList = new List<Item>();
        }

        private List<Item> _itemsList; 
        public List<Item> ItemsList 
        {
            get { return _itemsList; }
            set
            {
                _itemsList = value;
                OnPropertyChanged();
            } 
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async Task AddItem(Item item)
        {
            try
            {
                var items = _client.GetTable<Item>();
                await items.InsertAsync(item);
                GetTable();
            }
            catch (Exception e)
            {
                var page = new ContentPage();
                var result = page.DisplayAlert("Error", "Error adding data", "OK", null);
            }
        }

        public async Task GetTable()
        {
            try
            {
                var itemsTable = await _client.GetTable<Item>().ToListAsync();
                ItemsList.Clear();
                ItemsList = itemsTable;
            }
            catch(Exception e)
            {
                var page = new ContentPage();
                var result = page.DisplayAlert("Error", "Error loading data", "OK", null);
            }
        } 
    }
}
