using MagmaTestServer.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace MagmaTestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class queryController : ControllerBase
    {
        [HttpGet]
        [Route("check")]
        public Querychek GetFilesQuery()
        {
            Querychek querychek = new Querychek();
            var jsonList = StaticFileReader.ReadTheJsonFile()["files"];

            var falseResult = jsonList.Where(p => (bool)p["result"] == false).ToList();
            var trueResult = jsonList.Where(p => (bool)p["result"] == true).ToList();
            var totalResult = jsonList.ToList();

            //List<files> filesJson = JsonConvert.DeserializeObject<List<files>>("[" + String.Join(",", jsonList) + "]");
            querychek.total = totalResult.Count;
            querychek.correct = trueResult.Count;
            querychek.errors = falseResult.Count;
            if (querychek.errors > 1)
            {
                querychek.filenames = jsonList.Where(p => (bool)p["result"] == false)
                                              .Select(p => (string)p["filename"]).ToArray();
            }
            return querychek;
        }
    }
}
