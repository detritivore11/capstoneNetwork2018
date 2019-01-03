using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CapstoneWebService.Models;

namespace CapstoneWebService.Controllers
{
    public class VehicleInfoesController : ApiController
    {
        private CapstoneWebServiceContext db = new CapstoneWebServiceContext();

        // GET: api/VehicleInfoes
        public IQueryable<VehicleInfo> GetVehicleInfoes()
        {
            return db.VehicleInfoes;
        }

        // GET: api/VehicleInfoes/5
        [ResponseType(typeof(VehicleInfo))]
        public IHttpActionResult GetVehicleInfo(int id)
        {
            VehicleInfo vehicleInfo = db.VehicleInfoes.Find(id);
            if (vehicleInfo == null)
            {
                return NotFound();
            }

            return Ok(vehicleInfo);
        }

        // PUT: api/VehicleInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleInfo(int id, VehicleInfo vehicleInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(vehicleInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleInfoes
        [ResponseType(typeof(VehicleInfo))]
        public IHttpActionResult PostVehicleInfo(VehicleInfo vehicleInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleInfoes.Add(vehicleInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleInfo.ID }, vehicleInfo);
        }

        // DELETE: api/VehicleInfoes/5
        [ResponseType(typeof(VehicleInfo))]
        public IHttpActionResult DeleteVehicleInfo(int id)
        {
            VehicleInfo vehicleInfo = db.VehicleInfoes.Find(id);
            if (vehicleInfo == null)
            {
                return NotFound();
            }

            db.VehicleInfoes.Remove(vehicleInfo);
            db.SaveChanges();

            return Ok(vehicleInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleInfoExists(int id)
        {
            return db.VehicleInfoes.Count(e => e.ID == id) > 0;
        }
    }
}