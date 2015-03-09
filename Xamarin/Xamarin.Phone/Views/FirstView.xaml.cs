using Cirrious.MvvmCross.WindowsCommon.Views;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Xaml;
using System;
using Xamarin.Core.Model;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace Xamarin.Phone.Views
{
    public sealed partial class FirstView : MvxWindowsPage
    {

        private MobileServiceCollection<Item, Item> items;
        private IMobileServiceSyncTable<Item> todoTable = App.MobileService.GetSyncTable<Item>();

        public FirstView()
        {
            this.InitializeComponent();

            LoadTable().Wait();
        }

        private async Task LoadTable()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // Query that returns all items.   
                var liste = await todoTable.ToListAsync();
                var test = 1;
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }
            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ToDoListBox.ItemsSource = items;
            } 
        }

        private void ListBoxOnLoaded(object sender, RoutedEventArgs e)
        {
            var source = ToDoListBox.ItemsSource;
            var test = 1;
        }
    }
}
