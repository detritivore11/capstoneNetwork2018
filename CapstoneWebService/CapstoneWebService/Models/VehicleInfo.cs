using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneWebService.Models
{
    public class VehicleInfo
    {
        public int ID { get; set; }
        public string Version { get; set; }
        public string Key { get; set; }
        public IList<Param> Params { get; set; }
    }
}