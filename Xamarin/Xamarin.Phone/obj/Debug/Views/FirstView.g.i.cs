﻿

#pragma checksum "C:\PrivateRepo\Xamarin.Workshop\Xamarin\Xamarin.Phone\Views\FirstView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D5BD6BBF9F0D89993DFCBE352BD3DE71"
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
    partial class FirstView : global::Cirrious.MvvmCross.WindowsCommon.Views.MvxWindowsPage
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ListBox ToDoListBox; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox TextInput; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///Views/FirstView.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            ToDoListBox = (global::Windows.UI.Xaml.Controls.ListBox)this.FindName("ToDoListBox");
            TextInput = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("TextInput");
        }
    }
}



