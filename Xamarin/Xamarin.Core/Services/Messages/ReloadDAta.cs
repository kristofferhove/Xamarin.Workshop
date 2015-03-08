using Cirrious.MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Core.Services.Messages
{
    public class ReloadData : MvxMessage
    {
        public ReloadData(object sender) : base(sender)
        {
        }
    }
}
