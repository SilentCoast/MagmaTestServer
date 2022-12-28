using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MagmaTestServer
{
    public static class StaticFileReader
    {

        public static JToken ReadTheJsonFile()
        {
            try
            {
                using (StreamReader file = System.IO.File.OpenText("data.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    return  JToken.ReadFrom(reader);
                }
            }
            catch
            {
                return new JObject();
            }
        }
    }
}
