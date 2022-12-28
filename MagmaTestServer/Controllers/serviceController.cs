using MagmaTestServer.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagmaTestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class serviceController : ControllerBase
    {
        [HttpGet]
        [Route("serviceInfo")]
        public ServiceInfo GetServiceInfo()
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            serviceInfo.AppName = System.Reflection.Assembly.GetExecutingAssembly().FullName;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);

            serviceInfo.Version = fvi.FileVersion;
            serviceInfo.DateUtc = DateTime.UtcNow;
            return serviceInfo;
        }
    }
}
