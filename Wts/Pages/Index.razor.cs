using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using Wts.Helpers;


namespace Wts.Pages
{
    public partial  class Index
    {


        private string number { get; set; } = "";
        private string body { get; set; } = "";
        private string bodyText { get; set; } = "";

        bool request = false;
        bool sendRequest = false;
        async void send()
        {
            sendRequest = true;
            string serialize = "{\"messaging_product\": \"whatsapp\",\"recipient_type\": \"individual\",\"to\": \"" + number.Replace("+", "") + "\",\"type\": \"template\",\"template\": {\"name\": \"2ossa_kbirre\",\"language\": {\"code\": \"en_US\"},\"components\": [{\"type\": \"body\",\"parameters\": [{\"type\": \"text\",\"text\": \"" + body + "\"}]}]}}";

            request = await Request(serialize);

        }
        private async void Reply()
        {
            sendRequest = true;
            string serialize = "{\"messaging_product\": \"whatsapp\",\"recipient_type\":\"individual\",\"to\": \"" + number.Replace("+", "") + "\",\"type\": \"text\",\"text\": {\"preview_url\": false,\"body\": \"" + bodyText + "\"}}";

            request = await Request(serialize);

        }

        private async Task<bool> Request(String send)
        {
            try
            {

                using (HttpRequestMessage request = new()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new("https://graph.facebook.com/v13.0/111964231627717/messages"),
                    Content = new StringContent(send),

                })
                {
                    request.Headers.Add("Authorization", "Bearer EAAGpR1vYL1oBAJ2IrvteUJNGGLV8lv5M5pWa2wielnwZA9KtXDeXPwI4nj6vpecqopge0NCbjnPLf5hWpYbP7NUEtrO087FfJgZA1o8xvlFqESiYNSGiJRYxZB81IBEWBzcVn4TN3P1waaeuiGTpWYWJeeI7lP7IoM1ca4TIB3uGhlsYZBVj");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await Http.SendAsync(request);
                    Console.WriteLine(response.ToString());
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }





    }
}
