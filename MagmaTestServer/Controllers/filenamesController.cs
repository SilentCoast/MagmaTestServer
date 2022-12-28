using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace MagmaTestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class filenamesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get([FromQuery] bool correct)
        {
            using (StreamReader file = System.IO.File.OpenText("data.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var filesff= JToken.ReadFrom(reader)["files"];

                //JArray files = JArray.FromObject(StaticFileReader.ReadTheJsonFile().GetValue("files"));

                return filesff.Where(p => (bool)p["result"]==correct).Select(p => p["filename"].ToString());
            }

        }
    }
}
