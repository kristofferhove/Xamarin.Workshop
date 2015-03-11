using Fredrikstad.Forms.Models;
using Fredrikstad.Forms.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fredrikstad.Forms.Views
{
    public partial class ItemsTablePage : ContentPage
    {                               
        public ItemsTablePage(MobileServiceClient client)
        {
            InitializeComponent();

            this.ViewModel = new ItemsTableViewModel(client);
        }

        private ItemsTableViewModel ViewModel
        {
            get { return this.BindingContext as ItemsTableViewModel; }  
            set { this.BindingContext = value; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetTable();
        }

        private void AddItem_btn_clicked(object sender, EventArgs e)
        {
            ViewModel.AddItem(new Item(Input_field.Text));
            Input_field.Text = "";
        }
    }
}
