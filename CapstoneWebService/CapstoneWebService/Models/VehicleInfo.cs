using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneWebService.Models
{
    public class VehicleInfo
    {
        public int VID { get; set; }
        public string Version { get; set; }
        public string Key { get; set; }
        [NonSerialized]private List<Param> plist;
        public void Add(Param p) => plist.Add(p);
        public Param Get(int index) => plist[index];
        public VehicleInfo(int vID, string version, string key)
        {
            VID = vID;
            Version = version;
            Key = key;
            plist = new List<Param>();
        }
    }
}