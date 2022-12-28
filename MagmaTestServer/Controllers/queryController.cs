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
            
            var jsonList = StaticFileReader.ReadTheJsonFile()["files"];

            var totalResult = jsonList.Where(p => p["filename"].ToString().ToLower().StartsWith("query_")).ToList();

            var falseResult = totalResult.Where(p => (bool)p["result"] == false).ToList();
            var trueResult =  totalResult.Where(p => (bool)p["result"] == true).ToList();


            Querychek querychek = new Querychek();
            querychek.total = totalResult.Count;
            querychek.correct = trueResult.Count;
            querychek.errors = falseResult.Count;
            if (querychek.errors > 0)
            {
                querychek.filenames = falseResult.Select(p => (string)p["filename"]).ToArray();
            }
            return querychek;
        }
    }
}
