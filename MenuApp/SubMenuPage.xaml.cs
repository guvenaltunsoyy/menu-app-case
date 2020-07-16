using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MenuApp.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MenuApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubMenuPage : Page
    {
        public SubMenuPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is MenuItem menuItem)
            {
                menuItem.Items = menuItem.Items.OrderByDescending(x => x.Name.Length).ToList(); // it's for stackPanel width
                CollectionViewSource.Source = menuItem.Items;
            }else if (e.Parameter is List<MenuItem> listMenuItems)
            {
                try
                {
                    listMenuItems = listMenuItems.OrderByDescending(x => x.Name.Length).ToList();
                }
                catch (Exception)
                {
                    // ignored
                }

                CollectionViewSource.Source = listMenuItems;
            }
        }

        private void GwLineList_OnItemClickItemClick(object sender, ItemClickEventArgs e)
        {
            
            if (e.ClickedItem is MenuItem menuItem)
            {
                MainPage.Instance.AddToOrder( menuItem);
                if (MainPage.Instance.IsSubMenusFinished)
                {
                    MainPage.Instance.ShowMainMenu();
                    return;
                }
                MainPage.Instance.Next(menuItem);
            }
        }
    }
}
