using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Core.Model;
using Xamarin.Core.Services.Messages;
using Xamarin.Core.ViewModels;

namespace Xamarin.iOS.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        private MvxSubscriptionToken _reloadMessage;
        private UITableView toDoList;

        public override async void ViewDidLoad()
        {
            View = new UIView { BackgroundColor = UIColor.Red };
            base.ViewDidLoad();

            var messenger = Mvx.Resolve<IMvxMessenger>();
            _reloadMessage = messenger.SubscribeOnMainThread<ReloadData>(ReloadTableView);
            //ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
            {
                EdgesForExtendedLayout = UIRectEdge.None;
            }

            var txtField = new UITextField(new CGRect(10, 10, 300, 40));
            Add(txtField);

            txtField.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            //var btnAdd = UIButton.FromType(UIButtonType.Custom);
            var btnAdd = UIButton.FromType(UIButtonType.RoundedRect);
            btnAdd.Frame = new CGRect((float)UIScreen.MainScreen.Bounds.Width - 50, 17, 20, 20);
            btnAdd.SetTitle("+", UIControlState.Normal);
            btnAdd.SetTitle("-", UIControlState.Highlighted);
            btnAdd.Font = UIFont.FromName("Helvetica-BoldOblique", 26f);
            btnAdd.SetTitleColor(UIColor.Black, UIControlState.Normal);
            btnAdd.SetTitleColor(UIColor.Blue, UIControlState.Highlighted);
            Add(btnAdd);

            toDoList = new UITableView(new CGRect(0, 50, (float)UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - btnAdd.Bounds.Height - txtField.Bounds.Height));
            var source = new MvxStandardTableViewSource(toDoList, "TitleText Text;");
            toDoList.Source = source;
            Add(toDoList);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(source).To(vm => vm.ToDoList);
            set.Bind(txtField).To(vm => vm.Hello);
            set.Bind(btnAdd).To(vm => vm.AddItemCommand);
            set.Apply();

            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            var viewModel = (FirstViewModel)ViewModel;
            viewModel.RefreshDataAsync();
            toDoList.ReloadData();
        }

        private void ReloadTableView(ReloadData message)
        {
            toDoList.ReloadData();
        }
    }
}