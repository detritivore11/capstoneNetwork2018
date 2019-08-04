using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace agbotwebservice.Models
{
    public class VehicleDB : DbContext
    {
        public VehicleDB() : base(GetRDSConnectionString())
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<VehicleInfo> VehicleInfos { get; set; }
        public DbSet<Param> Params { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Param>().HasKey(p => new { p.ID, p.VehicleID });
        }
        public static VehicleDB Create()
        {
            return new VehicleDB();
        }
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["RDS_USERNAME"];
            string password = appConfig["RDS_PASSWORD"];
            string hostname = appConfig["RDS_HOSTNAME"];
            string port = appConfig["RDS_PORT"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}