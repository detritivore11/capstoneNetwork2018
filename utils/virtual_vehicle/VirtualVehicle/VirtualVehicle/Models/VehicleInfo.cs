// ************************************************************************************************
// CAPSTONE G03, 2018-2019
//
// Repository:
//  https://github.com/rahmant3/capstoneROS2018
//
// Description:
//  Object used to deserialize the JSON object containing vehicle parameters. Adapted from Web
//  Service capstone project.
//
// History:
//  2018-12-09 by Samuel Marriot
//  - Created.
//  2018-12-29 by Tamkin Rahman
//  - Add functions for getting displayable value.
// ************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VirtualVehicle.Models
{
    public class VehicleInfo
    {
        public int ID { get; set; }
        public string Version { get; set; }
        public string Key { get; set; }
        public IList<Param> Params { get; set; }

        public void sortParameters()
        {
            // Reference: https://stackoverflow.com/questions/3309188
            Params = Params.OrderBy(o => o.ID).ToList();
        }
    }
}