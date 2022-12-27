using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagmaTestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class allDataController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return StaticFileReader.ReadTheJsonFile().ToString();
        }


    }
}
