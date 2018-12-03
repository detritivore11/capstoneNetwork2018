using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneWebService.Models
{
    public class VehicleInfo
    {
        public int VID { get; set; }
        public string Version { get; set; }
        public string APIKey { get; set; }
        public string[] Params { get; set; }
    }
}