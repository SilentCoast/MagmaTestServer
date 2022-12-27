using MagmaTestServer.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace MagmaTestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class errorsController : ControllerBase
    {
        [HttpGet]
        public List<files> Get()
        {
            var jstring = StaticFileReader.ReadTheJsonFile()
                .GetValue("files").Where(p => (bool)p["result"] == false).ToList();
            //JArray newjsonString = (JArray)(((JObject)(JToken.ReadFrom(reader))).GetValue("files"));
            List<files> filesJson = JsonConvert.DeserializeObject<List<files>>("[" + String.Join(",",jstring) + "]");


            return filesJson;
            
        }
    }
}
