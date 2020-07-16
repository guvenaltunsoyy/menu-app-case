using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MenuApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MenuModel Menu;
        private Menu _mainMenu;
        private List<MenuItem> _order;
        private int _subMenusCount;
        private List<string> _subMenus;
        public bool IsSubMenusFinished;
        public static MainPage Instance { get; private set; }
        public MainPage()
        {
            this.InitializeComponent();
            CheckBackButton();
            Instance = this;
            ShowMainMenu();
            _order = new List<MenuItem>();
            _subMenus = new List<string>();
            _subMenusCount = 0;
        }
        public MenuModel GetMenu()
        {
            using (StreamReader r = new StreamReader("menu.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<MenuModel>(json);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            CheckBackButton();
        }

        public void ShowMainMenu()
        {
            Menu = GetMenu();
            _mainMenu = Menu.Menus.FirstOrDefault(x => x.Key.Equals("main"));
            SetHeader(_mainMenu?.Description ?? string.Empty);
            IsSubMenusFinished = false;
            StepFrameNavigate(typeof(SubMenuPage), _mainMenu?.Items);
            StepFrame.BackStack.Clear();
            CheckBackButton();

        }

        public void CheckBackButton()
        {
            btnBack.Visibility = StepFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }
        public void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            if (_subMenusCount != 0)
            {
                _order.RemoveAt(0);
                RefreshBoard();
            }
            StepFrame.GoBack();
            CheckBackButton();
        }

        public void StepFrameNavigate(Type type, object parameter, string header=null)
        {
            StepFrame.Navigate(type, parameter);
            CheckBackButton();
            if (!string.IsNullOrEmpty(header)) SetHeader(header);
        }

        public void SetHeader(string header)
        {
            TbStep.Text = header;
        }
        public void Next(MenuItem lastItem)
        {
            if (lastItem?.Items?.Count > 0)
            {
                StepFrameNavigate(typeof(SubMenuPage), lastItem.Items, Menu.Menus.FirstOrDefault(x => x.Key.Equals(lastItem.Name))?.Description);
            }else if (lastItem?.SubMenus?.Count > 0 && _subMenusCount == 0)
            {
                _subMenusCount = lastItem.SubMenus.Count;
                _subMenus = lastItem.SubMenus;
                SubMenusStep();
            }else if (_subMenusCount != 0)
            {
                SubMenusStep();
            }
        }
        public void AddToOrder(MenuItem item)
        {
            _order.Insert(0,item);
            TbTotalPrice.Text = _order.Sum(x => x.Price).ToString();
            WriteToBoard(item.Name, item.Price.ToString());
        }

        public void WriteToBoard(string text, string price)
        {
            TbOrder.Text = text+ "--- Ucret :" + price + "\n" + "-----------------" + "\n" + TbOrder.Text;
        }

        private void RefreshBoard()
        {
            TbOrder.Text = "";
            _order.ForEach(x =>
            {
                WriteToBoard(x.Name, x.Price.ToString());
            });
            TbTotalPrice.Text = _order.Sum(x => x.Price).ToString();
        }

        public void SubMenusStep()
        {
            var subMenu = _subMenus.FirstOrDefault();
            _subMenus.RemoveAt(0);
            _subMenusCount--;
            IsSubMenusFinished = _subMenusCount == 0;
            var menuItem = Menu.Menus.FirstOrDefault(x => x.Key.Equals(subMenu)); // find subMenu
            if (menuItem == null) // if null find in menu items
            {
                Menu.Menus.ForEach(x =>
                {
                    var _menuItem = x.Items.FirstOrDefault(y => y.Name.Equals(subMenu));
                    StepFrameNavigate(typeof(SubMenuPage), _menuItem);
                });
                return;
            }
            StepFrameNavigate(typeof(SubMenuPage), menuItem.Items, menuItem?.Description);
        }

        public async void Finish()
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Siparisiniz olusturulmustur.",
                Content = "Toplam tutar :" + TbTotalPrice.Text,
                CloseButtonText = "Tamam"
            };
            await noWifiDialog.ShowAsync();
            TbOrder.Text = "";
            TbTotalPrice.Text = "0";
            _order.Clear();
            _subMenus.Clear();
            _subMenusCount = 0;
            ShowMainMenu();
        }

        private void BtnFinish_OnClick(object sender, RoutedEventArgs e)
        {
            Finish();
        }
    }
    
}
