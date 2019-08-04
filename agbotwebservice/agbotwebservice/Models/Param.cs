using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace agbotwebservice.Models
{
    public class Param
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Units { get; set; }
        public int Timestamp { get; set; }
        public string Message { get; set; }
        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }
        public virtual VehicleInfo Vehicle { get; set; }
    }
}