using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Model;
using Telegram.Model.ViewModels;
using Telegram.Services.Customes;

namespace Telegram.Services
{
    public class UserServices
    {
        private HttpClient client;
        public UserServices()
        {
            client = new HttpClient();
        }

        public async Task<User> CreateUser(CreateUserViewModel user)
        {
            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var respons = await client.PostAsync(Constants.Create, content);
            if (respons.IsSuccessStatusCode)
            {
                string massage = await respons.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(massage);

            }
            return null;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var response = await client.GetAsync(Constants.GetAll);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<User>>(message);
            }
            return null;
        }


        public async Task<IEnumerable<Friend>> GetAllFriends()
        {
            var response = await client.GetAsync(Constants.urlFriend);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Friend>>(message);
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetAllUsersWithName(string name)
        {
            string api = Constants.GetAllWithName + $"?name={name}";
            var response = await client.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<User>>(message);
            }
            return null;
        }

        public async Task<User> Get(long id)
        {
            string api = Constants.GetAll + $"/{id}";
            var response = await client.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(message);
            }
            return null;
        }

        public async Task<User> GetFromPhoneNumber(string phone)
        {
            string api = Constants.url + $"get_from_phone_number?phone={phone}";
            var response = await client.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                var r = JsonConvert.DeserializeObject<User>(message);
                return r;
            }
            return null;
        }
    }
}
