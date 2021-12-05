using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace RestSharpConsole
{
    public static class UsingRestsharp
    {
        public static void CallTest()
        {
            var _url = ConfigurationManager.AppSettings["webapibaseurl"];
            if (!string.IsNullOrEmpty(_url))
            {
                RestClient _client = new RestClient(_url);
                var request = new RestRequest(_url, Method.GET) { RequestFormat = DataFormat.Json };
                var response = _client.Execute<Root>(request);

                if (response.Data == null)
                    throw new Exception(response.ErrorMessage);

                Root? myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content);
                if (myDeserializedClass != null)
                {
                    var jordan = myDeserializedClass.Countries.FirstOrDefault(c => c.CountryCode.Contains("JO"));

                    if (jordan != null)
                    {
                        Console.WriteLine($"country name :{jordan.Slug}");
                        Console.WriteLine($"TotalConfirmed:{jordan.TotalConfirmed}\nTotalDeaths:{jordan.TotalDeaths}");
                        Console.WriteLine($"NewConfirmed:{jordan.NewConfirmed}\nNewDeaths:{jordan.NewDeaths}");
                    }
                }
            }
        }
      


    }
}
