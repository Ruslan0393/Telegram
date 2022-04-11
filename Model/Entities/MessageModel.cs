using System;

namespace Telegram.Model
{
    public class MessageModel
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeleteDate { get; set; }

        public string Text { get; set; }

        public long ClientId { get; set; }

        public long UserId { get; set; }

    }
}
