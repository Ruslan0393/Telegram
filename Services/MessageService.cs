using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Model;
using Telegram.Model.ViewModels;

namespace Telegram.Services
{
    public class MessageService
    {
        private HttpClient client;
        public MessageService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<MessageModel>> GetMessages(long id)
        {
            string api = $"https://localhost:44384/api/Message?UserId={id}";
            var response = await client.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<IEnumerable<MessageModel>>(message);

                return res;
            }
            return null;
        }



        public async Task<MessageModel> SendMessage(SendMessageViewModel message)
        {
            string json = JsonConvert.SerializeObject(message);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var respons = await client.PostAsync("https://localhost:44384/api/Message", content);
            if (respons.IsSuccessStatusCode)
            {
                string massage = await respons.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MessageModel>(massage);

            }
            return null;
        }


    }
}
