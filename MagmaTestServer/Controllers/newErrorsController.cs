using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MagmaTestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class newErrorsController : ControllerBase
    {
        [HttpPost]
        public string AddErrors(string jsonErrors)
        {
            JToken jToken;
            //check if string valid
            try
            {
                jToken =  JToken.Parse(jsonErrors);
                if (jToken["scan"] == null)
                {
                    return "json string does not contain scan";
                }
                if (jToken["files"] == null)
                {
                    return "json string does not contain files";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            string path =$"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}" +
                $"_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.json";
            System.IO.File.WriteAllText($"jsonErrorStrings/{path}", jToken.ToString());

            return "";
        }
    }
}
