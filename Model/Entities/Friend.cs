using System;

namespace Telegram.Model
{
    public class Friend
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public long FriendId { get; set; }

        public long UserId { get; set; }

    }
}
