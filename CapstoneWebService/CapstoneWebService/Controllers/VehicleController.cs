using CapstoneWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneWebService.Controllers
{
    public class VehicleController : ApiController
    {
        VehicleInfo[] info = new VehicleInfo[]
        {
            new VehicleInfo { VID = 1, Version = "1.1.1", APIKey = "test", Params = new string[]{"temp"} },
            new VehicleInfo { VID = 2, Version = "1.2.3", APIKey = "test", Params = new string[]{"temp" } },
            new VehicleInfo { VID = 3, Version = "1.2.1", APIKey = "test", Params = new string[]{"temp" } }
        };

        public IEnumerable<VehicleInfo> GetAllInfo()
        {
            return info;
        }

        public IHttpActionResult GetInfo(int id)
        {
            var select = info.FirstOrDefault((v) => v.VID == id);
            if (select == null)
            {
                return NotFound();
            }
            return Ok(select);
        }
        public void PostInfo()
        {
        }
    }
}
