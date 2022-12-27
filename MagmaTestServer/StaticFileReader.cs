using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MagmaTestServer
{
    public static class StaticFileReader
    {
        public static JObject ReadTheJsonFile()
        {
            using (StreamReader file = System.IO.File.OpenText("data.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                return (JObject)JToken.ReadFrom(reader);
            }
        }
    }
}
