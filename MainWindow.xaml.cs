using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Controll;
using Telegram.Models;

namespace Telegram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

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
            if(sidebar_open_btn == new Thickness(0))
            {
                Sidebar_tg.Margin = new Thickness(-200);
                tempPanel.Height = 0;
            }
        }

        IList<UserModel> AllUsers = new List<UserModel>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AllUsers.Add(new UserModel { Id = 1, FirstName = "Ruslan", LastName = "Jabbarganov", Username = "ruslan0393", PhoneNumber = "+998990895249", ContextMoc = "Assalomu aleykum", Date = "14:43" });
            AllUsers.Add(new UserModel { Id = 2, FirstName = "Zafar", LastName = "Sobirov", Username = "zafa123", PhoneNumber = "+998990895249", ContextMoc = "Okey", Date = "4:23" });
            AllUsers.Add(new UserModel { Id = 3, FirstName = "Sardor", LastName = "Alimov", Username = "alimov007", PhoneNumber = "+998990895249", ContextMoc = "Siz albatta .Netni o'rganishingiz kerak agrada kuchli dasturchi bo'lmoqchi bo'lsangiz", Date = "9:11" });
            AllUsers.Add(new UserModel { Id = 1, FirstName = "Ruslan", LastName = "Jabbarganov", Username = "ruslan0393", PhoneNumber = "+998990895249", ContextMoc = "Assalomu aleykum", Date = "14:43" });
            AllUsers.Add(new UserModel { Id = 2, FirstName = "Zafar", LastName = "Sobirov", Username = "zafa123", PhoneNumber = "+998990895249", ContextMoc = "Okey", Date = "4:23" });
            AllUsers.Add(new UserModel { Id = 3, FirstName = "Sardor", LastName = "Alimov", Username = "alimov007", PhoneNumber = "+998990895249", ContextMoc = "Siz albatta .Netni o'rganishingiz kerak agrada kuchli dasturchi bo'lmoqchi bo'lsangiz", Date = "9:11" });
            AllUsers.Add(new UserModel { Id = 1, FirstName = "Ruslan", LastName = "Jabbarganov", Username = "ruslan0393", PhoneNumber = "+998990895249", ContextMoc = "Assalomu aleykum", Date = "14:43" });
            AllUsers.Add(new UserModel { Id = 2, FirstName = "Zafar", LastName = "Sobirov", Username = "zafa123", PhoneNumber = "+998990895249", ContextMoc = "Okey", Date = "4:23" });
            AllUsers.Add(new UserModel { Id = 3, FirstName = "Sardor", LastName = "Alimov", Username = "alimov007", PhoneNumber = "+998990895249", ContextMoc = "Siz albatta .Netni o'rganishingiz kerak agrada kuchli dasturchi bo'lmoqchi bo'lsangiz", Date = "9:11" });
            AllUsers.Add(new UserModel { Id = 1, FirstName = "Ruslan", LastName = "Jabbarganov", Username = "ruslan0393", PhoneNumber = "+998990895249", ContextMoc = "Assalomu aleykum", Date = "14:43" });
            AllUsers.Add(new UserModel { Id = 2, FirstName = "Zafar", LastName = "Sobirov", Username = "zafa123", PhoneNumber = "+998990895249", ContextMoc = "Okey", Date = "4:23" });
            AllUsers.Add(new UserModel { Id = 3, FirstName = "Sardor", LastName = "Alimov", Username = "alimov007", PhoneNumber = "+998990895249", ContextMoc = "Siz albatta .Netni o'rganishingiz kerak agrada kuchli dasturchi bo'lmoqchi bo'lsangiz", Date = "9:11" });
            AllUsers.Add(new UserModel { Id = 1, FirstName = "Ruslan", LastName = "Jabbarganov", Username = "ruslan0393", PhoneNumber = "+998990895249", ContextMoc = "Assalomu aleykum", Date = "14:43" });
            AllUsers.Add(new UserModel { Id = 2, FirstName = "Zafar", LastName = "Sobirov", Username = "zafa123", PhoneNumber = "+998990895249", ContextMoc = "Okey", Date = "4:23" });
            AllUsers.Add(new UserModel { Id = 3, FirstName = "Sardor", LastName = "Alimov", Username = "alimov007", PhoneNumber = "+998990895249", ContextMoc = "Siz albatta .Netni o'rganishingiz kerak agrada kuchli dasturchi bo'lmoqchi bo'lsangiz", Date = "9:11" });
            AllUsers.Add(new UserModel { Id = 1, FirstName = "Ruslan", LastName = "Jabbarganov", Username = "ruslan0393", PhoneNumber = "+998990895249", ContextMoc = "Assalomu aleykum", Date = "14:43" });
            AllUsers.Add(new UserModel { Id = 2, FirstName = "Zafar", LastName = "Sobirov", Username = "zafa123", PhoneNumber = "+998990895249", ContextMoc = "Okey", Date = "4:23" });
            AllUsers.Add(new UserModel { Id = 3, FirstName = "Sardor", LastName = "Alimov", Username = "alimov007", PhoneNumber = "+998990895249", ContextMoc = "Siz albatta .Netni o'rganishingiz kerak agrada kuchli dasturchi bo'lmoqchi bo'lsangiz", Date = "9:11" });
            AllUsers.Add(new UserModel { Id = 1, FirstName = "Ruslan", LastName = "Jabbarganov", Username = "ruslan0393", PhoneNumber = "+998990895249", ContextMoc = "Assalomu aleykum", Date = "14:43" });
            AllUsers.Add(new UserModel { Id = 2, FirstName = "Zafar", LastName = "Sobirov", Username = "zafa123", PhoneNumber = "+998990895249", ContextMoc = "Okey", Date = "4:23" });
            AllUsers.Add(new UserModel { Id = 3, FirstName = "Sardor", LastName = "Alimov", Username = "alimov007", PhoneNumber = "+998990895249", ContextMoc = "Siz albatta .Netni o'rganishingiz kerak agrada kuchli dasturchi bo'lmoqchi bo'lsangiz", Date = "9:11" });
            AllUsers.Add(new UserModel { Id = 1, FirstName = "Ruslan", LastName = "Jabbarganov", Username = "ruslan0393", PhoneNumber = "+998990895249", ContextMoc = "Assalomu aleykum", Date = "14:43" });


            foreach (var user in AllUsers)
            {
                this.Dispatcher.Invoke(() =>
                {
                    var pri = new UserList();
                    pri.UserName.Text = user.FirstName + " " + user.LastName;
                    pri.UserContent.Text = user.ContextMoc;
                    pri.UserTime.Text = user.Date;
                    Item_control.Items.Add(pri);
                });
            }           
        }


        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //BrushConverter b = new BrushConverter();
            //((Border)sender).Background = (Brush)b.ConvertFrom("#212B35");
        }


        private void Button_Click_Select_Item(object sender, RoutedEventArgs e)
        {
            if(Item_control.ItemsSource != null)
            {
                var i = (Item_control.ItemsSource as UserModel).Id;
                MessageBox.Show(i.ToString());
            }
        }

    }
}
