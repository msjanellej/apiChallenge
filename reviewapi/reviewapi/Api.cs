using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;


namespace reviewapi
{
    public static class Api
    {
        public static JObject GetYelpApiData()
        {
            var webRequest = WebRequest.Create("https://api.yelp.com/v3/businesses/jKV8bxDv9VH2GvAnh5YRbw/reviews");
            webRequest.Method = "GET";
            webRequest.Headers.Add("Cache-Control", "no-cache");
            webRequest.Headers.Add("Authorization", "Bearer " + ApiKey.apiKey);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            var stream = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
            var content = stream.ReadToEnd();
            Newtonsoft.Json.Linq.JObject result = JsonConvert.DeserializeObject<JObject>(content);
            return result;
        }
}
}
