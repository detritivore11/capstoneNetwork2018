using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapstoneWebService.Models
{
    public class Param
    {
        public string Name { get; set; }
        public int ID { get; set; }
        [Required]
        public string Value { get; set; }
        public string Type { get; set; }
        public string Units { get; set; }
        public int Timestamp { get; set; }
        public string Message { get; set; }
        public int VehicleID { get; set; }
    }
}