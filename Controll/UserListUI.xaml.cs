using System.Windows;
using System.Windows.Controls;

namespace Telegram.Controll
{

    public partial class UserListUI : UserControl
    {
        public UserListUI()
        {
            InitializeComponent();
        }


        static public long idUser = 0;
        private void Button_MouseDown(object sender, RoutedEventArgs e)
        {
            string str = Id.Text;
            idUser = long.Parse(str);
        }


    }

}
