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
        public string Get([FromQuery] bool correct)
        {
            
            var filesff = StaticFileReader.ReadTheJsonFile()["files"];
            if(filesff == null) { return "ERROR"; }

            IEnumerable<string> results = filesff.Where(p => (bool)p["result"] == correct).Select(p => p["filename"].ToString());

            JObject job = new JObject();
            job.Add("filenames", JToken.FromObject(results));
            return job.ToString();

        }
    }
}
