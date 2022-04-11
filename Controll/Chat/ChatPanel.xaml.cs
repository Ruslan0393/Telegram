using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telegram.Model;
using Telegram.Services;

namespace Telegram.Controll.Chat
{
  
    public partial class ChatPanel : UserControl
    {
        private MessageService messageService;
        public IEnumerable<MessageModel> messages;
        public ChatPanel()
        {
            InitializeComponent();
            messageService = new MessageService();
        }


        private void DispatcherTimerSampleForDataBaseUpdateCheck()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += TimerTicker;
            timer.Start();
        }

        async void TimerTicker(object sender, EventArgs e)
        {
            messages = await messageService.GetMessages(UserListUI.idUser);
        }




        private void DispatcherTimerSample()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += timer_TickAsync;
            timer.Start();
        }

        void timer_TickAsync(object sender, EventArgs e)
        {
            DispatcherTimerSampleForDataBaseUpdateCheck();
            Massage_item_control.Items.Clear();
            if (UserListUI.idUser > 0)
            {
                Massage_item_control.Items.Clear();
                if (messages != null)
                {
                    var users = messages;
                    foreach (var user in users)
                    {
                        var pri = new Message();
                        pri.MessageText.Text = user.Text;
                        pri.TimeText.Text = user.CreatedDate.ToString("HH:mm");
                        pri.owner.Text = user.UserId.ToString();
                        Massage_item_control.Items.Add(pri);
                    }

                }
            }
        }


        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Massage_item_control.Items.Clear();
            DispatcherTimerSample();
        }
    }
}
