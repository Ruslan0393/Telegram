using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telegram.Model;
using Telegram.Services;

namespace Telegram.Controll
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : UserControl
    {

        private UserServices _userService;
        private FriendService _friendService;



        public UserList()
        {
            InitializeComponent();
            _userService = new UserServices();
            _friendService = new FriendService();
        }



        public async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Item_control.Items.Clear();
           


            if (MainWindow.OwnerId > 0)
            {
                IEnumerable<Friend> friend = await _friendService.GetMyFriends(MainWindow.OwnerId);
                Item_control.Items.Clear();
                if (friend != null)
                {
                    foreach(var k in friend)
                    {
                        User user = await _userService.Get(k.FriendId);

                        var pri = new UserListUI();

                        pri.UserName.Text = user.FirstName + " " + user.LastName;
                        pri.UserContent.Text = user.Password;
                        pri.UserTime.Text = user.CreatedDate.ToString("HH:mm");
                        pri.Id.Text = user.Id.ToString();
                        Item_control.Items.Add(pri);

                    }

                }
            }


        }
    }
}
