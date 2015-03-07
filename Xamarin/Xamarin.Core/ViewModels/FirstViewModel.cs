using Cirrious.MvvmCross.ViewModels;

namespace Xamarin.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
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
            var test = Hello;
            var test1 = 1;
        }
    }
}
