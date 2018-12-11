using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneWebService.Models
{
    public class VehicleDB
    {
        private static List<VehicleInfo> testDB;
        public static void Init()
        {
            testDB = new List<VehicleInfo>();
        }
        public static void Add(VehicleInfo vInfo)
        {
            int index = testDB.FindIndex((v) => v.ID == vInfo.ID);
            if (index < 0)
            {
                testDB.Add(vInfo);
            }
            else
            {
                testDB[index] = vInfo;
            }
        }
        public static VehicleInfo Get(int id)
        {
            var select = testDB.FirstOrDefault((v) => v.ID == id);
            return select;
        }
        public static List<VehicleInfo> GetAll()
        {
            return testDB;
        }
    }
}