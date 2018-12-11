using CapstoneWebService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CapstoneWebService.Controllers
{
    public class VehicleController : ApiController
    {

        public IHttpActionResult GetAllInfo()
        {
            List<VehicleInfo> info = VehicleDB.GetAll();
            string result = JsonConvert.SerializeObject(info);
            return Ok(result);
        }

        public IHttpActionResult GetInfo(int id)
        {
            VehicleInfo info = VehicleDB.Get(id);
            if (info != null)
            {
                string result = JsonConvert.SerializeObject(info);
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        public async Task<IHttpActionResult> PostInfo()
        {
            try
            {
                //byte[] input = await Request.Content.ReadAsByteArrayAsync();
                //string value = System.Text.Encoding.UTF8.GetString(input);
                string value = await Request.Content.ReadAsStringAsync();
                VehicleInfo vInfo = JsonConvert.DeserializeObject<VehicleInfo>(value);
                VehicleDB.Add(vInfo);
                return Ok(value);
            }
            catch (JsonException)
            {
                return NotFound();
            }
        }
    }
}
