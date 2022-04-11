using System.IO;

namespace Telegram.Services.Customes
{
    public class Constants
    {
        public static readonly string url = "https://localhost:44384/api/User/";
        public static readonly string urlFriend = "https://localhost:44384/api/Friend";


        public static readonly string Create = Path.Combine(url, "add_user");
        public static readonly string GetAll = Path.Combine(url, "get");
        public static readonly string GetAllWithName = Path.Combine(url, "get_name");




        public static readonly string GetFriend = Path.Combine(url);



    }
}
