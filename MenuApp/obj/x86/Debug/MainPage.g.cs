﻿#pragma checksum "C:\Users\Phygitalmind\source\repos\MenuApp\MenuApp\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "007D62EC1474BB68C4F57A20ACA33EC7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MenuApp
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 12
                {
                    this.CollectionViewSource = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 5: // MainPage.xaml line 70
                {
                    this.StepFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 6: // MainPage.xaml line 82
                {
                    this.TbTotalPrice = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // MainPage.xaml line 83
                {
                    this.TbOrder = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // MainPage.xaml line 47
                {
                    this.btnBack = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnBack).Click += this.BtnBack_OnClick;
                }
                break;
            case 9: // MainPage.xaml line 54
                {
                    this.TbStep = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // MainPage.xaml line 58
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.BtnFinish_OnClick;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

