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
using UIKit;
using Xamarin.Core.Services.Messages;
using Xamarin.Core.ViewModels;

namespace Xamarin.iOS.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        private MvxSubscriptionToken _reloadMessage;
        private UITableView toDoList;

        public override void ViewDidLoad()
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

            var label = new UITextField(new CGRect(10, 10, 300, 40));
            Add(label);

            var btnAdd = UIButton.FromType(UIButtonType.Custom);
            btnAdd.Frame = new CGRect((float)UIScreen.MainScreen.Bounds.Width - 50, 17, 20, 20);
            btnAdd.SetImage(UIImage.FromBundle("Add-New"), UIControlState.Normal);
            btnAdd.SetImage(UIImage.FromBundle("Add-New-pressed"), UIControlState.Highlighted);
            btnAdd.SetImage(UIImage.FromBundle("Add-New-pressed"), UIControlState.Selected);
            Add(btnAdd);

            toDoList = new UITableView(new CGRect(0, 50, (float)UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - btnAdd.Bounds.Height - label.Bounds.Height));
            var source = new MvxStandardTableViewSource(toDoList, "TitleText Text;");
            toDoList.Source = source;
            Add(toDoList);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(source).To(vm => vm.ToDoList);
            set.Bind(label).To(vm => vm.Hello);
            set.Bind(btnAdd).To(vm => vm.AddItemCommand);
            set.Apply();

            toDoList.ReloadData();
        }

        private void ReloadTableView(ReloadData message)
        {
            toDoList.ReloadData();
        }
    }


    //public class FirstView : MvxViewController      MvxTableViewController
    //{
    //    public override void ViewDidLoad()
    //    {
    //        View = new UIView { BackgroundColor = UIColor.Red };
    //        base.ViewDidLoad();

    //        // ios7 layout
    //        if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
    //        {
    //            EdgesForExtendedLayout = UIRectEdge.None;
    //        }

    //        var label = new UITextField(new CGRect(10, 10, 300, 40));
    //        Add(label);

    //        var btnAdd = UIButton.FromType(UIButtonType.Custom);
    //        btnAdd.Frame = new CGRect((float)UIScreen.MainScreen.Bounds.Width - 50, 17, 20, 20);
    //        btnAdd.SetImage(UIImage.FromBundle("Add-New"), UIControlState.Normal);
    //        btnAdd.SetImage(UIImage.FromBundle("Add-New-pressed"), UIControlState.Highlighted);
    //        btnAdd.SetImage(UIImage.FromBundle("Add-New-pressed"), UIControlState.Selected);
    //        Add(btnAdd);

    //        var toDoList = new UITableView(new CGRect(0, 50, (float)UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - btnAdd.Bounds.Height - label.Bounds.Height));
    //        string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
    //        var todolist = new List<string>();
    //        todolist.Add("Element");
    //        toDoList.Source = new TableSource(todolist);
    //        Add(toDoList);

    //        var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
    //        set.Bind(toDoList.Source).To(vm => vm.ToDoList);
    //        set.Bind(label).To(vm => vm.Hello);
    //        set.Bind(btnAdd).To(vm => vm.AddItemCommand);
    //        set.Apply();
    //    }
    //}
}