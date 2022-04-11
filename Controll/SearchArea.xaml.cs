using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telegram.Model;
using Telegram.Services;

namespace Telegram.Controll
{

    public partial class SearchArea : UserControl
    {
        UserServices _userServices = new UserServices();
        public IEnumerable<User> Users;
        public SearchArea()
        {
            InitializeComponent();
            GetData();
        }



        public async void GetData()
        {
            Users = await _userServices.GetAllUsers();
        }



        private void SmartDispatcherTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_TickAsync;
            timer.Start();
        }

        void timer_TickAsync(object sender, EventArgs e)
        {
            string searchTxt = MainWindow.searchMain;
           

            Item_control_search.Items.Clear();

            if (Users != null)
            {
                foreach (var user in Users)
                {
                    if (user.FirstName.ToUpper().StartsWith(searchTxt.ToUpper()) || user.LastName.ToUpper().StartsWith(searchTxt.ToUpper()))
                    {
                        var pri = new SearchAreaItem();

                        pri.UserName.Text = user.FirstName + " " + user.LastName;
                        pri.Id.Text = user.Id.ToString();
                        Item_control_search.Items.Add(pri);
                    }
                }
            }

        }




        public void UserControl_Loaded123(object sender, RoutedEventArgs e)
        {
            Item_control_search.Items.Clear();
            SmartDispatcherTimer();
        }
    }
}
