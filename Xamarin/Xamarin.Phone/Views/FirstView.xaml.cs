using Cirrious.MvvmCross.WindowsCommon.Views;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Xaml;
using System;
using Xamarin.Core.Model;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Xamarin.Core.ViewModels;

namespace Xamarin.Phone.Views
{
    public sealed partial class FirstView : MvxWindowsPage
    {
        public FirstView()
        {
            this.InitializeComponent();
        }

        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var todoItem = new Item { Text = TextInput.Text };
            //await InsertTodoItem(todoItem);
        }

        private void Grid_OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = (FirstViewModel)ViewModel;
            viewModel.RefreshDataAsync();
        }
    }
}
