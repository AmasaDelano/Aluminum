using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Aluminum.Web
{
    public class JsonConfig
    {
        public static void Configure()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}