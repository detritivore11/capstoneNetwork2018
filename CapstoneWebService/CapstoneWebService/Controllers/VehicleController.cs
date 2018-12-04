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
        List<VehicleInfo> info = new List<VehicleInfo>
        {
            new VehicleInfo (1, "1.1.1", "test"),
            new VehicleInfo (2, "2.1.1", "test"),
            new VehicleInfo (3, "1.2.3", "test")
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
        public void PostInfo(string value)
        {

        }
    }
}
