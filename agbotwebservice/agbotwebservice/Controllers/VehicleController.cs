using agbotwebservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace agbotwebservice.Controllers
{
    public class VehicleController : ApiController
    {
        private VehicleDB db = VehicleDB.Create();
        public IHttpActionResult GetAllInfo()
        {
            var info = db.VehicleInfos.Include(x => x.Params);
            foreach (var vehicle in info)
            {
                vehicle.Key = "";
            }
            string result = JsonConvert.SerializeObject(info, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(result);
        }

        public async Task<IHttpActionResult> GetInfo(int id)
        {
            var info = await db.VehicleInfos.Include(x => x.Params).SingleOrDefaultAsync(x => x.ID == id);
            if (info != null)
            {
                info.Key = "";
                string result = JsonConvert.SerializeObject(info,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
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
                var parms = vInfo.Params;
                db.VehicleInfos.AddOrUpdate(vInfo);
                await db.SaveChangesAsync();
                foreach (var parm in parms)
                {
                    parm.VehicleID = vInfo.ID;
                    db.Params.AddOrUpdate(parm);
                    await db.SaveChangesAsync();
                }
                return Ok(value);
            }
            catch (JsonException)
            {
                return BadRequest();
            }
        }
    }
}