using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CapstoneWebService.Models
{
    public class VehicleInfo
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Version { get; set; }
        public string Key { get; set; }
        public ICollection<Param> Params { get; set; }
    }
}