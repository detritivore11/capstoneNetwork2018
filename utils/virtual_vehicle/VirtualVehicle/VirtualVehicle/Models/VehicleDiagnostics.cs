// ************************************************************************************************
// CAPSTONE G03, 2018-2019
//
// Repository:
//  https://github.com/rahmant3/capstoneROS2018
//
// Description:
//  Object used to manage and serialize the JSON object for the Web Service.
//
// History:
//  2019-01-03 by Tamkin Rahman
//  - Created.
// ************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net;

namespace VirtualVehicle.Models
{
    public class VehicleDiagnostics
    {
        public VehicleInfo vehicle = null;
        private string url = string.Empty;

        public VehicleDiagnostics(int id, string version, string key, string url)
        {
            this.vehicle = new VehicleInfo();

            this.vehicle.ID = id;
            this.vehicle.Version = version;
            this.vehicle.Key = key;
            this.vehicle.Params = new List<Param>();

            this.SetUrl(url);
        }

        public void SetUrl(string url)
        {
            if (url.EndsWith("/"))
            {
                this.url = string.Format("{0}{1}", url, this.vehicle.ID);
            }
            else
            {
                this.url = string.Format("{0}/{1}", url, this.vehicle.ID);
            }
        }

        public bool AddParam(string name, int id, string value, string type, string units, int timestamp, string message = "")
        {
            bool rc = false;
            if (this.FindParam(id) < 0)
            {
                this.vehicle.Params.Add(new Param()
                {
                    Name = name,
                    ID = id,
                    Value = value,
                    Type = type,
                    Units = units,
                    Timestamp = timestamp,
                    Message = message
                });

                this.vehicle.sortParameters();

                rc = true;
            }

            return rc;
        }

        public bool AddParam(Param parm)
        {
            bool rc = false;
            if (this.FindParam(parm.ID) < 0)
            {
                this.vehicle.Params.Add(parm);

                this.vehicle.sortParameters();

                rc = true;
            }

            return rc;
        }

        public bool SetTimestamp(int id, long timestamp)
        {
            bool rc = false;
            int ix = this.FindParam(id);
            if (ix >= 0)
            {
                this.vehicle.Params[ix].Timestamp = timestamp;
                rc = true;
            }

            return rc;
        }

        public bool SetValue(int id, string value)
        {
            bool rc = false;
            int ix = this.FindParam(id);
            if (ix >= 0)
            {
                this.vehicle.Params[ix].Value = value;
                rc = true;
            }

            return rc;
        }

        public int FindParam(int id)
        {
            bool found = false;
            int ix = -1;
            
            if ((this.vehicle != null) && (this.vehicle.Params != null))
            {
                // Note: This foreach loop uses a break statement.
                for (ix = 0; ix < this.vehicle.Params.Count(); ix++)
                {
                    if (this.vehicle.Params[ix].ID == id)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    ix = -1;
                }
            }

            return ix;
        }

        public bool PostData(out string error)
        {
            bool rc = false;
            error = string.Empty;
            string output = JsonConvert.SerializeObject(this.vehicle);

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                try
                {
                    string HtmlResult = wc.UploadString(this.url, output);
                    if (!string.IsNullOrEmpty(HtmlResult))
                    {
                        rc = true;
                    }
                    else
                    {
                        error = "Didn't receive the expected response.";
                    }
                }
                catch (System.Net.WebException e)
                {
                    error = e.Message;
                }
            }

            return rc;
        }
    }
    
}
