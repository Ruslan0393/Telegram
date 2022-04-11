using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Telegram.Controll;
using Telegram.Model;
using Telegram.Model.ViewModels;
using Telegram.Services;

namespace Telegram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User Owner;

        public static long OwnerId = 0;

        public static string searchMain = "";

        private UserServices _userService;

        public SearchArea searchArea;

        private UserList user1;
        public MainWindow()
        {
            _userService = new UserServices();
        }




        #region functions for customize
        private void Close_window(object sender, EventArgs e) => Close();


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private void Minimize_window(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;


        private void Click_open_sidebar_btn(object sender, RoutedEventArgs e)
        {
            Sidebar_tg.Margin = new Thickness(0);
            tempPanel.Height = 500;
        }

        private void TelegramMouseDown(object sender, MouseButtonEventArgs e)
        {
            Thickness sidebar_open_btn = Sidebar_tg.Margin;
            if (sidebar_open_btn == new Thickness(0))
            {
                Sidebar_tg.Margin = new Thickness(-200);
                tempPanel.Height = 0;
            }
        }
        #endregion





        private void SmartDispatcherTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_TickAsync;
            timer.Start();
        }


        async void timer_TickAsync(object sender, EventArgs e)
        {
            if (searchFieald.Text != "")
            {
                UsersResalt.Visibility = Visibility.Collapsed;
                SearchReslat.Visibility = Visibility.Visible;
            }
            else
            {
                UsersResalt.Visibility = Visibility.Visible;
                SearchReslat.Visibility = Visibility.Collapsed;
            }


            UserListUI userListUi = new UserListUI();
            if (UserListUI.idUser > 0)
            {
                long l = UserListUI.idUser;
                var client = await _userService.Get(l);
                ChatUserName.Text = client.FirstName + " " + client.LastName;
                TimeOnline.Text = "last seen recently";
                ChatArea.Width = 480;



                if (userMessage.Text != "")
                {
                    IconAudioAndSentMessage.Kind = MaterialDesignThemes.Wpf.PackIconKind.Send;
                }
                else
                {
                    IconAudioAndSentMessage.Kind = MaterialDesignThemes.Wpf.PackIconKind.Microphone;
                }
            }
            else
            {
                ChatArea.Width = 0;
            }

            if (Owner != null)
            {
                GlobalUserName.Text = Owner.FirstName + " " + Owner.LastName;
                GlobalUserPhone.Text = Owner.PhoneNumber;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SmartDispatcherTimer();
            searchFieald.Focus();
            chat_scroll.ScrollToEnd();
        }

        private void TextBox_KeyDown_for_send_message(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (userMessage.Text != "")
                {
                    BtnSentMessage(sender, null);
                }
            }
        }

        private async void BtnSentMessage(object sender, RoutedEventArgs e)
        {
            if (userMessage.Text != "")
            {


                SendMessageViewModel sendMessageView = new SendMessageViewModel
                {
                    Text = userMessage.Text,
                    UserId = OwnerId,
                    ClientId = UserListUI.idUser,
                    Owner = true
                };

                MessageService messageService = new MessageService();
                await messageService.SendMessage(sendMessageView);


                chat_scroll.ScrollToEnd();
                userMessage.Clear();
                userMessage.Focus();
            }

        }

        private void StartBtnEnter(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void BackToStartPanel(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
        }







        private void BtnEnterPhone(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }

        private void BackToPhonePanel(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private async void PasswordLogin(object sender, RoutedEventArgs e)
        {
            string num = PhoneNumberInput.Text.Substring(1);
            var res = await _userService.GetFromPhoneNumber(num);
            if (res != null)
            {
                if (PasswordInput.Text == res.Password)
                {
                    Owner = res;
                    OwnerId = res.Id;
                    user1 = new UserList();
                    user1.UserControl_Loaded(sender, null);
                    MainTabControl.SelectedIndex = 4;
                }
                else PasswordInputErrorTxt.Visibility = Visibility.Visible;
            }
            else MainTabControl.SelectedIndex = 3;
        }

        private void BackToPasswordPanel(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }

        private async void SignUpAccount(object sender, RoutedEventArgs e)
        {
            User resalt = await _userService.CreateUser(new CreateUserViewModel
            {
                FirstName = FirstNameInput.Text,
                LastName = LastNameInput.Text,
                PhoneNumber = PhoneNumberInput.Text.Substring(1),
                Password = PasswordInput.Text
            });

            if (resalt != null)
            {
                Owner = resalt;
                MainTabControl.SelectedIndex = 4;
            }

        }



      

        private void searchFieald_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                searchMain = searchFieald.Text;
                searchArea = new SearchArea();
                searchArea.UserControl_Loaded123(sender, null);
            }
        }
    }
}
