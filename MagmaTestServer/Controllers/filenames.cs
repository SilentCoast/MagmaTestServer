using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace MagmaTestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class filenames : ControllerBase
    {
        [HttpGet]
        public string Get([FromQuery] bool correct)
        {
            JArray files = JArray.FromObject(StaticFileReader.ReadTheJsonFile().GetValue("files"));

            return String.Join(", ",(from p in files where ((bool)p["result"] == correct) select p));

        }
    }
}
