using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Telegram.Controll.Chat
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : UserControl
    {
        public Message()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (owner.Text != MainWindow.OwnerId.ToString())
            {
                BrushConverter b = new BrushConverter();
                MessageBorder.Background = Brushes.Blue;
                wrapMessage.HorizontalAlignment = HorizontalAlignment.Left;
            }
        }
    }
}
