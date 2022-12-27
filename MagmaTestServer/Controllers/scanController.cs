using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MagmaTestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class scanController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return ((StaticFileReader.ReadTheJsonFile().GetValue("scan"))??"NULL").ToString();
        }
    }
}
