namespace Telegram.Model.ViewModels
{
    public class SendMessageViewModel
    {
        public string Text { get; set; }

        public long ClientId { get; set; }

        public long UserId { get; set; }

        public bool Owner { get; set; }
    }
}
