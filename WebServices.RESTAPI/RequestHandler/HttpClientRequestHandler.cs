using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WebService.RESTAPI
{
    public class HttpClientRequestHandler : IRequestHandler
    {

        public const string Url = "http://services.groupkt.com/state/get/USA/all";

        public JToken GetAllStateResponse(string url)
        {
            // Creating an instance of HttpClient
            using (var httpClient = new HttpClient())
            {                
                // Get JSON respone
                var response = httpClient.GetStringAsync(new Uri(url)).Result;

                // Response is not received in array format. Thus, typecasting to JArray object based on response header
                JObject joResponse = JObject.Parse(response);
                JObject ojObject = (JObject)joResponse["RestResponse"];
                JArray jArray = (JArray)ojObject["result"];
                return jArray;
                 
            }
        }
    }
}
