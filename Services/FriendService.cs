using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Model;

namespace Telegram.Services
{
    public class FriendService
    {
        private HttpClient client;
        public FriendService()
        {
            client = new HttpClient();
        }



        public async Task<Friend> GetFriend(long id)
        {
            string api = $"https://localhost:44384/api/Friend/{id}";
            var response = await client.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<Friend>(message);

                return res;
            }
            return null;
        }


        public async Task<IEnumerable<Friend>> GetMyFriends(long id)
        {
            string api = $"https://localhost:44384/api/Friend/my-friend?id={id}";
            var response = await client.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<IEnumerable<Friend>>(message);

                return res;
            }
            return null;
        }


    }
}
