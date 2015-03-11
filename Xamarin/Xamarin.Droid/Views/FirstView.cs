using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Xamarin.Core.ViewModels;

namespace Xamarin.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            var viewmodel = (FirstViewModel)ViewModel;
            viewmodel.RefreshDataAsync();
        }
    }
}