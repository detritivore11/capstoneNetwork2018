namespace CapstoneWebService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CapstoneWebService.Models;
    using Newtonsoft.Json;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CapstoneWebService.Models.VehicleDB context)
        {
            string initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 4, \"key\": \"asdf\"}";
            VehicleInfo vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            var parms = vInfo.Params;
            foreach (var parm in parms)
            {
                parm.VehicleID = vInfo.ID;
                context.Params.AddOrUpdate(parm);
            }
            context.VehicleInfos.AddOrUpdate(vInfo);
            initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 5, \"key\": \"asdf\"}";
            vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            parms = vInfo.Params;
            foreach (var parm in parms)
            {
                parm.VehicleID = vInfo.ID;
                context.Params.AddOrUpdate(parm);
            }
            context.VehicleInfos.AddOrUpdate(vInfo);
            initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 6, \"key\": \"asdf\"}";
            vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            parms = vInfo.Params;
            foreach (var parm in parms)
            {
                parm.VehicleID = vInfo.ID;
                context.Params.AddOrUpdate(parm);
            }
            context.VehicleInfos.AddOrUpdate(vInfo);
        }
    }
}
