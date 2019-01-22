using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CapstoneWebService.Models
{
    public class VehicleDB : DbContext
    {
        public VehicleDB() : base(DBHelper.GetRDSConnectionString())
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<VehicleInfo> VehicleInfos { get; set; }
        public DbSet<Param> Params { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Param>().HasKey(p => new { p.ID, p.VehicleID });
        }
    }
}