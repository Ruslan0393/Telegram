using System.Windows;
using System.Windows.Controls;
using Telegram.Services;

namespace Telegram.Controll
{
   
    public partial class SearchAreaItem : UserControl
    {
        public UserServices userService;
        public FriendService friendService;
        public SearchAreaItem()
        {
            InitializeComponent();
            friendService = new FriendService();
        }

        static public long idUser = 0;
        private async void Button_MouseDown(object sender, RoutedEventArgs e)
        {
            string str = Id.Text;
            idUser = long.Parse(str);
            var resalt = await friendService.GetFriend(idUser);
            if(resalt.FriendId == 1)
            {
                 
            }

        }


    }
}
