﻿

#pragma checksum "C:\PrivateRepo\Xamarin.Workshop\Xamarin\Xamarin.Phone\Views\FirstView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F4C9749D57B0DD333385A3B2CE66F8DC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xamarin.Phone.Views
{
    partial class FirstView : global::Cirrious.MvvmCross.WindowsCommon.Views.MvxWindowsPage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 57 "..\..\..\Views\FirstView.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.ListBoxOnLoaded;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


